using LexerLib.Automatons;
using LexerLib.Exceptions;
using LexerLib.Situations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public class Lexer : ILexer
	{
		private IState[] states;
		//private ICharReader reader;

		public Lexer( params IRule[] Rules)
		{

			if (Rules == null) throw new ArgumentNullException("Rules");

	
			IAutomatonTableFactory automatonTableFactory;
			ISituationSegmentFactory situationSegmentFactory;
			ISituation rootSituation;

			situationSegmentFactory = new SituationSegmentFactory();
			rootSituation=situationSegmentFactory.BuildRootSituation(Rules);

			automatonTableFactory = new AutomatonTableFactory();
			this.states=automatonTableFactory.BuildStates(rootSituation);

		}
		



		public TokenMatch Read(ICharReader Reader)
		{
			char input;
			int? index = 0;
			IState currentState;
			StringBuilder sb;
			IRule reductionRule;
			string lastGoodValue=null;
			long lastGoodPosition=0;
			IRule lastGoodRule=null;
			TokenMatch result;

			if (Reader == null) throw new ArgumentNullException("Reader");

			sb = new StringBuilder();

			currentState = states[0];
			while(true)
			{
				if (Reader.EOF)
				{
					if (lastGoodPosition != 0) break;
					throw new Exceptions.EndOfStreamException(Reader.Position);
				}
				else
				{
					input = Reader.Read();
					index = currentState.GetNextStateIndex(input);
				}
				
				if (index == null)
				{
					if (lastGoodPosition != 0) break;
					throw new InvalidInputException(Reader.Position, input);
				}
				
				sb.Append(input);
				currentState = states[index.Value];

				reductionRule = currentState.Reductions.FirstOrDefault();
				if (reductionRule != null)
				{
					lastGoodPosition = Reader.Position;
					lastGoodRule = reductionRule;
					lastGoodValue = sb.ToString();
				}
			}

			Reader.Seek(lastGoodPosition);

			result = new TokenMatch();
			result.Success = true;
			result.Token = new Token(lastGoodRule.Name,lastGoodValue);
			result.Tags = lastGoodRule.Tags.ToArray();
			return result;
		}

		public TokenMatch TryRead(ICharReader Reader)
		{
			char input;
			int? index = 0;
			IState currentState;
			StringBuilder sb;
			IRule reductionRule;
			long lastGoodPosition = 0;
			IRule lastGoodRule = null;
			string lastGoodValue = null;
			TokenMatch result;

			if (Reader == null) throw new ArgumentNullException("Reader");

			sb = new StringBuilder();

			currentState = states[0];
			while (true)
			{
				if (Reader.EOF)
				{
					if (lastGoodPosition == 0) lastGoodValue = sb.ToString();
					break;
				}
				else
				{
					input = Reader.Read();
					index = currentState.GetNextStateIndex(input);
				}

				sb.Append(input);

				if (index == null)
				{
					if (lastGoodPosition == 0) lastGoodValue = sb.ToString();
					break;
				}

				currentState = states[index.Value];

				reductionRule = currentState.Reductions.FirstOrDefault();
				if (reductionRule != null)
				{
					lastGoodPosition = Reader.Position;
					lastGoodRule = reductionRule;
					lastGoodValue=sb.ToString();
				}
			}

			result = new TokenMatch();
			if (lastGoodRule != null)
			{
				result.Success = true;
				result.Tags = lastGoodRule.Tags.ToArray();
				result.Token = new Token(lastGoodRule.Name, lastGoodValue);
				Reader.Seek(lastGoodPosition);
			}
			else
			{
				result.Token = new Token(null, lastGoodValue);
			}

			return result;
		}



	}
}

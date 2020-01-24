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
			Token lastGoodToken=new Token();
			long lastGoodPosition=0;
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
					lastGoodToken = new Token(reductionRule.Name, sb.ToString());
				}
			}

			Reader.Seek(lastGoodPosition);

			result = new TokenMatch();
			result.Success = true;
			result.Token = lastGoodToken;
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
			TokenMatch result;
			Token token=new Token();

			if (Reader == null) throw new ArgumentNullException("Reader");

			sb = new StringBuilder();

			currentState = states[0];
			while (true)
			{
				if (Reader.EOF)
				{
					if (lastGoodPosition == 0) token = new Token(null, sb.ToString());
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
					if (lastGoodPosition == 0) token = new Token(null, sb.ToString());
					break;
				}

				currentState = states[index.Value];

				reductionRule = currentState.Reductions.FirstOrDefault();
				if (reductionRule != null)
				{
					lastGoodPosition = Reader.Position;
					token = new Token(reductionRule.Name, sb.ToString());
				}
			}

			result = new TokenMatch();
			if (token.Class != null)
			{
				result.Success = true;
				Reader.Seek(lastGoodPosition);
			}
			result.Token = token;

			
			return result;
		}



	}
}

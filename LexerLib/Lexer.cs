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
		



		public Token Read(ICharReader Reader)
		{
			char input;
			int? index = 0;
			IState currentState;
			StringBuilder sb;
			string _class;
			Token lastGoodToken=new Token();
			long lastGoodPosition=0;

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

				_class = currentState.Reductions.FirstOrDefault();
				if (_class != null)
				{
					lastGoodPosition = Reader.Position;
					lastGoodToken = new Token(_class, sb.ToString());
				}
			}

			Reader.Seek(lastGoodPosition);
			return lastGoodToken;
		}

		public bool TryRead(ICharReader Reader,out Token Token)
		{
			char input;
			int? index = 0;
			IState currentState;
			StringBuilder sb;
			string _class;
			long lastGoodPosition = 0;

			if (Reader == null) throw new ArgumentNullException("Reader");

			Token = new Token();
			sb = new StringBuilder();

			currentState = states[0];
			while (true)
			{
				if (Reader.EOF)
				{
					if (lastGoodPosition == 0) Token = new Token(null, sb.ToString());
					break;
				}
				else
				{
					input = Reader.Read();
					index = currentState.GetNextStateIndex(input);
				}

				if (index == null)
				{
					if (lastGoodPosition == 0) Token = new Token(null, sb.ToString());
					break;
				}

				sb.Append(input);
				currentState = states[index.Value];

				_class = currentState.Reductions.FirstOrDefault();
				if (_class != null)
				{
					lastGoodPosition = Reader.Position;
					Token = new Token(_class, sb.ToString());
				}
			}

			Reader.Seek(lastGoodPosition);
			return Token.Class!=null;
		}



	}
}

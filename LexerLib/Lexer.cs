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

			if (Reader == null) throw new ArgumentNullException("Reader");

			sb = new StringBuilder();

			currentState = states[0];
			while(true)
			{
				
				if (Reader.EOF)
				{
					_class = currentState.Reductions.FirstOrDefault();
					if (_class == null) throw new Exceptions.EndOfStreamException(Reader.Position);
					return new Token(_class, sb.ToString());
				}
				else
				{
					input = Reader.Peek();
					index = currentState.GetNextStateIndex(input);

					// cannot read further
					if (index == null)
					{
						_class = currentState.Reductions.FirstOrDefault();
						if (_class == null) throw new InvalidInputException(Reader.Position, input);
						return new Token(_class, sb.ToString());
					}

					currentState = states[index.Value];
					Reader.Pop();
					sb.Append(input);
				}
			}
		
		}

		public bool TryRead(ICharReader Reader,out Token Token)
		{
			char input;
			int? index = 0;
			IState currentState;
			StringBuilder sb;
			string _class;

			if (Reader == null) throw new ArgumentNullException("Reader");

			sb = new StringBuilder();

			currentState = states[0];
			while (true)
			{

				if (Reader.EOF)
				{
					_class = currentState.Reductions.FirstOrDefault();
					Token= new Token(_class, sb.ToString());
					return _class != null;
				}
				else
				{
					input = Reader.Peek();
					index = currentState.GetNextStateIndex(input);

					// cannot read further
					if (index == null)
					{
						_class = currentState.Reductions.FirstOrDefault();
						Token = new Token(_class, sb.ToString());
						return _class != null;
					}

					currentState = states[index.Value];
					Reader.Pop();
					sb.Append(input);
				}
			}
		}



	}
}

using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public class SituationSegment : ISituationSegment
	{
		IEnumerable<ITransition> ISituationSegment.InputTransitions => InputTransitions;
		public List<ITransition> InputTransitions
		{
			get;
			set;
		}
		IEnumerable<ISituation> ISituationSegment.OutputSituations => OutputSituations;
		public List<ISituation> OutputSituations
		{
			get;
			set;
		}

		public SituationSegment()
		{
			InputTransitions = new List<ITransition>();
			OutputSituations = new List<ISituation>();
		}

		
	}
}

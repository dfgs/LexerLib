﻿using LexerLib.Predicates;
using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public interface ISituationSegmentFactory
	{
		ISituation BuildRootSituation(IPredicate Predicate);
		ISituationSegment BuildSituationSegment(IPredicate Predicate, ISituationSegment NextSegment);


	}

}

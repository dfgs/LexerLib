﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public abstract class ShiftPredicate : Predicate, IShiftPredicate
	{
		public abstract bool Accept(char Input);


		
	}
}

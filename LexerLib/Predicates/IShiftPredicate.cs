﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public interface IShiftPredicate:IPredicate
	{
		bool Accept(char Input);
	}
}

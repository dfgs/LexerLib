﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Exceptions
{
	public class EndOfStreamException:LexerException
	{
		
	
		public EndOfStreamException(long Position):base(Position)
		{
		}
	}
}

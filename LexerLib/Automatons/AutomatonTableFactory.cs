using LexerLib.Situations;
using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Automatons
{
	public class AutomatonTableFactory : IAutomatonTableFactory
	{
		public AutomatonTableFactory()
		{

		}

		IState[] IAutomatonTableFactory.BuildStates(ISituation RootSituation)
		{
			return BuildStates(RootSituation);
		}

		private bool AreEquals(List<ISituation> Situations1, List<ISituation> Situations2)
		{
			if (Situations1.Count != Situations2.Count) return false;
			
			foreach(ISituation situation in Situations1)
			{
				if (!Situations2.Contains(situation)) return false;
			}

			return true;
		}

		public State[] BuildStates(ISituation RootSituation)
		{
			List<State> states;
			List<SituationCollection> situationCollections;
			List<SituationCollection> openList;
			List<ISituation> nextSituations;

			SituationCollection currentSituationCollection,existingSituationCollection;

			if (RootSituation == null) throw new ArgumentNullException("RootSituation");
			states = new List<State>();
			situationCollections = new List<SituationCollection>();
			openList = new List<SituationCollection>();

			currentSituationCollection = new SituationCollection();
			currentSituationCollection.State = new State();
			currentSituationCollection.Items.Add(RootSituation);

			situationCollections.Add(currentSituationCollection);
			states.Add(currentSituationCollection.State);
			
			openList.Add(currentSituationCollection);
			while (openList.Count > 0)
			{
				currentSituationCollection = openList[0];
				openList.RemoveAt(0);

				for (char input = char.MinValue; input < char.MaxValue; input++)
				{
					nextSituations = new List<ISituation>();
					foreach (ISituation situation in currentSituationCollection.Items)
					{
						foreach (ITransition transition in situation.Transitions)
						{
							if (transition is IReductionTransition reductionTransition)
							{
								currentSituationCollection.State.CreateReduction(reductionTransition.Rule);
								continue;
							}
							if (transition is IShiftTransition shiftTransition)
							{
								if (shiftTransition.Predicate.Accept(input)) nextSituations.Add(shiftTransition.TargetSituation);
							}
						}
					}
					if (nextSituations.Count == 0) continue;

					existingSituationCollection = situationCollections.FirstOrDefault(item => AreEquals(item.Items, nextSituations));
					if (existingSituationCollection == null)
					{
						existingSituationCollection = new SituationCollection();
						existingSituationCollection.Items = nextSituations;
						existingSituationCollection.State = new State();

						situationCollections.Add(existingSituationCollection);
						states.Add(existingSituationCollection.State);
						openList.Add(existingSituationCollection);
					}

					currentSituationCollection.State.CreateShift(input, states.IndexOf(existingSituationCollection.State));

				}

			}

			return states.ToArray();
		}


	}
}

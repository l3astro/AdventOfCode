

namespace Chronospatial.Computer
{
	public class Method2
	{
		public class MiniComputer2
		{
			int registerA;
			int registerB;
			int registerC;

			public MiniComputer2(int registerA, int registerB, int registerC)
			{
				this.registerA = registerA;
				this.registerB = registerB;
				this.registerC = registerC;
			}

			public bool computing(List<int> program)
			{
				int insPointer = 0; //points to current instruction in program
				List<int> output = new List<int>();

				while (insPointer < program.Count)
				{
					int combo = getCombo(program[insPointer + 1]);

					switch (program[insPointer])
					{
						case 0:
							registerA = registerA / ((int)Math.Pow(2, combo));
							insPointer += 2;
							break;

						case 1:
							registerB = registerB ^ program[insPointer + 1];
							insPointer += 2;
							break;

						case 2:
							registerB = combo % 8;
							insPointer += 2;
							break;

						case 3:
							if (registerA == 0)
							{
								insPointer += 2;
								break;
							}
							else
							{
								insPointer = program[insPointer + 1];
								break;
							}

						case 4:
							registerB = registerB ^ registerC;
							insPointer += 2;
							break;

						case 5:
							output.Add(combo % 8);
							if (output.Last() != program[output.Count - 1])
							{
								return false;
							}
							insPointer += 2;
							break;

						case 6:
							registerB = registerA / ((int)Math.Pow(2, combo));
							insPointer += 2;
							break;

						case 7:
							registerC = registerA / ((int)Math.Pow(2, combo));
							insPointer += 2;
							break;
					}
				}

				return true;
			}

			private int getCombo(int i)
			{
				if (i < 4)
				{
					return i;
				}
				else if (i == 4)
				{
					return registerA;
				}
				else if (i == 5)
				{
					return registerB;
				}
				else if (i == 6)
				{
					return registerC;
				}
				return 0; //should not happen
			}
		}
	}

}


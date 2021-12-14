namespace MyCalculator
{
    enum Operation
    {
        None,
        Add,
        Subbtraction,
        Multiply,
        Divide
    }

    class MyFunctions
    {
        #region Calc
        public static double? Calc(double? num1, double? num2, Operation operation)
        {
            double? returned = null;
            switch (operation)
            {
                case Operation.None:
                    {
                        returned = null;
                        break;
                    }
                case Operation.Add:
                    {
                        returned = num1 + num2;
                        break;
                    }
                case Operation.Subbtraction:
                    {
                        returned = num1 - num2;
                        break;
                    }
                case Operation.Multiply:
                    {
                        returned = num1 * num2;
                        break;
                    }
                case Operation.Divide:
                    {
                        if (num2 != 0)
                            returned = num1 / num2;
                        else
                            returned = null;
                        break;
                    }
                default: { returned = null; break; }
            }

            return returned;
        }
        #endregion

        #region Calc2
        public static Results Calc2(double num1, double num2, Operation operation)
        {
            Results returned = new Results { Sonuc = null, SonucString = "None" };
            switch (operation)
            {
                case Operation.None:
                    {
                        returned = new Results { Sonuc = null, SonucString = "None" };
                        break;
                    }
                case Operation.Add:
                    {
                        returned = new Results { Sonuc = num1 + num2, SonucString = "Add" };
                        break;
                    }
                case Operation.Subbtraction:
                    {
                        returned = new Results { Sonuc = num1 - num2, SonucString = "Subtraction" };
                        break;
                    }
                case Operation.Multiply:
                    {
                        returned = new Results { Sonuc = num1 * num2, SonucString = "Multiply" };
                        break;
                    }
                case Operation.Divide:
                    {
                        if (num2 != 0)
                            returned = new Results { Sonuc = num1 / num2, SonucString = "Divide" };
                        else
                            returned = new Results { Sonuc = null, SonucString = "Infinity" };
                        break;
                    }
                default: { returned = new Results { Sonuc = null, SonucString = "None" }; break; }
            }

            return returned;
        }
        #endregion
    }
}

namespace ApplicationCore
{
    internal static class ArrayPrinter
    {
        public static void DoActionWith<T>(T[] arrayForPrinting)
        {
            if (arrayForPrinting == null)
            {
                throw new ArgumentNullException("cannot print null array");
            }
            Console.WriteLine("Array {");

            for (int i = 0; i < arrayForPrinting.Length; i++)
            {
                Console.WriteLine($"{i} -> {arrayForPrinting[i]}");
            }

            Console.WriteLine("}");
        }
    }

    internal delegate void TestDelegate();

    internal static class VisualTests
    {
        public static void PerformAllTests()
        {
            TestDelegate[] setOfTests = new TestDelegate[]
            {
                  new TestDelegate(Test1)
                , new TestDelegate(Test2)
                , new TestDelegate(Test3)
                , new TestDelegate(Test4)
                , new TestDelegate(Test5)
                , new TestDelegate(Test6)
                , new TestDelegate(Test7)
                , new TestDelegate(Test8)
                , new TestDelegate(Test9)
                , new TestDelegate(Test10)
                , new TestDelegate(Test11)
            };

            foreach (TestDelegate currentTest in setOfTests)
            {
                currentTest.Invoke();

                Console.WriteLine("\n");
            }
        }


        public static void Test1()
        {
            var list = new LinkedList.LinkedList(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Console.WriteLine("Test #1 (params init):");

            ArrayPrinter.DoActionWith(list.ToArray());

            Console.WriteLine("");
        }

        public static void Test2()
        {
            var list = new LinkedList.LinkedList(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Console.WriteLine($"Test #2 (first method, positive): {list.GetFirstElementCompletelyDivivesBy(3)}");
        }

        public static void Test3()
        {
            Console.Write($"Test #3 (first method, negative): ");

            try
            {
                var list = new LinkedList.LinkedList(1, 4, 7, 4, 9, 3, 1, 7, 8, 3, 2);

                Console.WriteLine(list.GetFirstElementCompletelyDivivesBy(5));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("cannot find the suitable element");
            }
        }

        public static void Test4()
        {
            var list = new LinkedList.LinkedList(1, 4, 7, 4, 9, 3, 1, 7, 8, 3, 2);

            Console.WriteLine($"Test #4 (second method):");

            list.ZeroEvenPosedElems();
            ArrayPrinter.DoActionWith(list.ToArray());
        }

        public static void Test5()
        {
            var list = new LinkedList.LinkedList(1, 8, 5, 9, -1, 3, 2, 6, 4, 8, 3, 9, 1, 0);

            Console.WriteLine($"Test #5 (third method):");

            var filteredList = list.GetAllElementsGreaterThan(4);

            ArrayPrinter.DoActionWith(filteredList.ToArray());
        }

        public static void Test6()
        {
            var list = new LinkedList.LinkedList(1, 8, 5, 9, -1, 3, 2, 6, 4, 8, 3, 9, 1, 0);

            Console.WriteLine($"Test #6 (third method):");

            var filteredList = list.GetAllElementsGreaterThan(11);

            ArrayPrinter.DoActionWith(filteredList.ToArray());
        }

        public static void Test7()
        {
            var list = new LinkedList.LinkedList(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Console.WriteLine($"Test #7 (fourth method):");

            list.RemoveOddPosedOnes();

            ArrayPrinter.DoActionWith(list.ToArray());
        }

        public static void Test8()
        {
            var list = new LinkedList.LinkedList(0, 1);

            Console.WriteLine($"Test #8 (fourth method):");

            list.RemoveOddPosedOnes();

            ArrayPrinter.DoActionWith(list.ToArray());
        }

        public static void Test9()
        {
            var list = new LinkedList.LinkedList(0);

            Console.WriteLine($"Test #9 (fourth method):");

            list.RemoveOddPosedOnes();

            ArrayPrinter.DoActionWith(list.ToArray());
        }

        public static void Test10()
        {
            var list = new LinkedList.LinkedList();

            Console.WriteLine($"Test #10 (fourth method):");

            list.RemoveOddPosedOnes();

            ArrayPrinter.DoActionWith(list.ToArray());
        }

        public static void Test11()
        {
            var list = new LinkedList.LinkedList();

            Console.WriteLine($"Test #11:");

            list.Add(1);
            list.Add(4);
            list.Add(5);
            list.Add(0);
            list.Add(4);
            list.Add(13);
            list.Add(1337);

            ArrayPrinter.DoActionWith(list.ToArray());
        }
    }

    public static class EntryPoint
    {
        public static void Main(string[] args)
        {
            VisualTests.PerformAllTests();
        }
    }
}

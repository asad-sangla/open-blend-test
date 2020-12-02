using System;

namespace Interview_test
{
    class Program
    {
        static void Main()
        {
            #region Test4
            Console.WriteLine("Test 4 - Read and validate excel sheet data.");

            var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}Files\\OpenBlendMeetings.xlsx";
            var excelSheetRows = ValidateExcelDataQuestion.ReadData(filePath);

            foreach (var (rowNumber, dataValidationResult, rowData) in excelSheetRows)
            {
                var rowValidationStatus = dataValidationResult ? "Valid Row" : "Invalid Row";
                Console.WriteLine($"{rowNumber} - {rowValidationStatus} - {rowData}");
            }
            Console.WriteLine("\n");
            #endregion



            #region Test3
            Console.WriteLine("Test 3 - BinaryTree Test");
            var tree = new BinaryTree<Node>
            {
                NodeValue = new Node(0),
                LeftBranch = new BinaryTree<Node>
                {
                    NodeValue = new Node(0),
                    LeftBranch = new BinaryTree<Node>(),
                    RightBranch = new BinaryTree<Node> { NodeValue = new Node(0) }
                },
                RightBranch = new BinaryTree<Node> { NodeValue = new Node(0) }
            };
            Console.WriteLine($"BinaryTree Test count: {tree.Count()}");
            Console.WriteLine("\n");
            #endregion



            #region Test2
            Console.WriteLine("Test 2 - Call A Test");
            var a = new A();
            var result = a.Foo();
            Console.WriteLine($"result of F00 method: {result}");
            Console.WriteLine("\n");
            #endregion


            #region Test1
            Console.WriteLine("Test 1 - check 'adabra cadabra' an an input for the following code");
            string textInput = "adabra cadabra"; // add data in advance
            //textInput = Console.ReadLine();
            string[] args = textInput.Split(" ");

            if (args.Length == 0)
                if (args.Length == 1)
                    Console.WriteLine("Not enough inputs");
                else
                    Console.WriteLine(args[0] + args[1]);

            Console.WriteLine("\n");
            #endregion
        }

        
    }
}
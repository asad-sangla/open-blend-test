# OpenBlend Developer Test

Solved Developer Test for OpenBlend Interview Session.

## Test 1

What happens when we run this program (it compiles)  and type adabra cadabra in to the console?

```C#
using System;
public class Test3
{
    public static void Main()
    {
        string textInput = "";
        textInput = Console.ReadLine();
        string[] args = textInput.Split(" ");
        if (args.Length == 0)
            if (args.Length == 1)
                Console.WriteLine("Not enough inputs");
            else
                Console.WriteLine(args[0] + args[1]);
    }
}
```

### Answer - Test 1

Process exits with a code. System will not display any output because we split arguments input with space and `args.lenght is = 2` and else statement is for nested if statement

## Test 2

In the following class:

```C#
public class A
{
    public bool Foo()
    {
        return GetType() == typeof(A);
    }
}
 ```

What does the `Foo()` method return? Could the method be simplified with an implementation that just returned this value, whilst ensuring all the behaviour of any system that used the method was not changed?

### Answer - Test 2

Foo() method returns Boolean value which is true.

```C#
public class A
{
    public bool Foo () => GetType() == typeof(A);
}
```

## Test 3

Given the following class:

```C#
public class BinaryTree<T> where T : class
{
    public T NodeValue { get; set; }
    public BinaryTree<T> LeftBranch { get; set; }
    public BinaryTree<T> RightBranch { get; set; }
}
```

implement the following member function:

```C#
public int Count()
{
    // …
}
```

### Answer - Test 3

```C#
public int Count()
{
    return CountNodes(this);
    static int CountNodes(BinaryTree<T> tree) => tree?.NodeValue == null
        ? 0
        : 1 + CountNodes(tree.LeftBranch) + CountNodes(tree.RightBranch);
}

```

## Test 4

OpenBlend gives structure to meetings between team members and their managers.  We bulk load users into the system from spreadsheets sent to us by our clients.  In each row we expect the email address of the team member and the email address of their manager.

What validation should we perform on each row of data before we save it into our database?

### Answer - Test 4

I would like to create a validation method for it by using Regular expression for email validation and to check 2 emails per row I'll run a LINQ query to validate number of emails in a row and then I'll reurn the result.  
__Detailed Answer is in the solution file in class `ValidateExcelDataQuestion.cs`, please run the code to see the working result__

```C#
//Just to validate email address
private static bool IsValidEmail(string value) => !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);

//This will in sa separate method, I have just put it here to provide an overview
 //select data of all columns
var rowObjects = Enumerable.Range(0, reader.FieldCount)
                            .Select(i => reader.GetValue(i))
                            .ToList();

//validate email address and count how many times it exists in the row
var emailsCountInRow = rowObjects.Count(x => x != null && IsValidEmail(x.ToString()));

//just select data in plan string
var rowData = string.Join(" | ", rowObjects.ConvertAll(x => x?.ToString()).ToArray());
```

## Test 5

For each meeting (“session”) between a team member and their manager, a row is added to the SessionHistory table in the OpenBlend database.  Amongst other things, the SessionHistory table has integer columns for the team-member and manager ids, and a “SessionDate” datetime column for the session date.

Write a query to show how many sessions there were each month in the years 2018 and 2019 – i.e. the result set should have 24 rows, 1 for each month across those 2 years.

### Answer - Test 5

```SQL
SELECT DATEPART(YEAR, sh.SessionDate) AS SessionYear, FORMAT(sh.SessionDate, 'MMMM') AS SessionMonth, COUNT(*) SessionsPerMonth
FROM SessionHistory sh
WHERE YEAR(sh.SessionDate) IN (2018, 2019)
GROUP BY DATEPART(YEAR, sh.SessionDate), FORMAT(sh.SessionDate, 'MMMM')
ORDER BY MIN(sh.SessionDate)
```

## Test 6

Isobel: “Josh is innocent”  
Josh: “George is guilty”  
George: “Tara is guilty”  
Tara: “Isobel is innocent”  
Only the guilty person is lying, all the others are telling the truth.  Who is guilty?

### Answer - Test 6

My answer, __George__ is lying and he the guilty person.

## Test 7

What problems can you find in this picture?
![alt text](https://raw.githubusercontent.com/asad-sangla/open-blend-test/main/open-blen-screen-shot.jpg?token=ABUYDWUHBS2G47UM7OQAK3S72CZFC)

### Answer - Test 7

1. The table alignment is incorrect floating outside the wrapper div.

2. Spacing between column is less, Text is not aligned properly.

3. Heading is not aligned to the left side.

4. Usability issue, cannot understand that it is button for acount page or just a the letter of username.

5. Does not have arrow button __<__ to close left menu

![alt text](https://raw.githubusercontent.com/asad-sangla/open-blend-test/main/open-blen-screen-shot-issues.jpg?token=ABUYDWTGYOA63CP5AH7TSGS72CZPY)

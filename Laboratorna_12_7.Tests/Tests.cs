namespace Laboratorna_12_7.Tests;

[TestFixture]
public class Tests
{
    private const string TestFileName = "text.txt";

    [SetUp]
    public void SetUp()
    {
        // Створення тестового файлу з даними для кожного тесту
        string[] lines = { "1", "2", "3", "4", "5" };
        File.WriteAllLines(TestFileName, lines);
    }

    [TearDown]
    public void TearDown()
    {
        // Видалення тестового файлу після кожного тесту
        File.Delete(TestFileName);
    }

    [Test]
    public void CreateListFromFile_Test()
    {
        // Arrange
        LinkedListNode expected = new LinkedListNode(1);
        expected.Next = new LinkedListNode(2);
        expected.Next.Next = new LinkedListNode(3);
        expected.Next.Next.Next = new LinkedListNode(4);
        expected.Next.Next.Next.Next = new LinkedListNode(5);

        // Act
        LinkedListNode result = Program.CreateListFromFile(TestFileName);

        // Assert
        Assert.AreEqual(expected.Data, result.Data);
        Assert.AreEqual(expected.Next.Data, result.Next.Data);
        Assert.AreEqual(expected.Next.Next.Data, result.Next.Next.Data);
        Assert.AreEqual(expected.Next.Next.Next.Data, result.Next.Next.Next.Data);
        Assert.AreEqual(expected.Next.Next.Next.Next.Data, result.Next.Next.Next.Next.Data);
        Assert.IsNull(result.Next.Next.Next.Next.Next); // Перевіряємо, що наступний елемент останнього вузла - null
    }
    
    [Test]
    public void ReplaceNodes_Test()
    {
        // Arrange
        LinkedListNode input = new LinkedListNode(1);
        input.Next = new LinkedListNode(2);
        input.Next.Next = new LinkedListNode(1);
        input.Next.Next.Next = new LinkedListNode(4);
        int m = 1;
        int n = 3;

        LinkedListNode expected = new LinkedListNode(3);
        expected.Next = new LinkedListNode(2);
        expected.Next.Next = new LinkedListNode(3);
        expected.Next.Next.Next = new LinkedListNode(4);

        // Act
        LinkedListNode result = Program.ReplaceNodes(input, m, n);

        // Assert
        Assert.AreEqual(expected.Data, result.Data);
        Assert.AreEqual(expected.Next.Data, result.Next.Data);
        Assert.AreEqual(expected.Next.Next.Data, result.Next.Next.Data);
        Assert.AreEqual(expected.Next.Next.Next.Data, result.Next.Next.Next.Data);
        Assert.IsNull(result.Next.Next.Next.Next); // Перевіряємо, що наступний елемент останнього вузла - null
    }
}
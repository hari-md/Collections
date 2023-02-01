
using Collections;
using NUnit.Framework.Constraints;

namespace Collection.UnitTests
{

    public class CollectionTests
    {

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Act & Arrange
            var nums = new Collection<int>();

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(5);

            Assert.That(nums[0], Is.EqualTo(5));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(5, 10, 15);

            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15]"));
        }

        [Test]
        public void Test_Collection_AddText()
        {
            var numbers = new Collection<string>("Zero", "One");

            numbers.Add("Two");

            Assert.That(numbers.ToString(), Is.EqualTo("[Zero, One, Two]"));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();

            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";

            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");
            // Act
            var item0 = names[0];
            var item1 = names[1];
            // Assert
            Assert.That(item0, Is.EqualTo("Peter"));
            Assert.That(item1, Is.EqualTo("Maria"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collection<string>("Bob", "Joe");

            Assert.That(() => { var name = names[-1]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[2]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[500]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe]"));
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void Test_Collection_GetByInvalidIndexDDT(int index)
        {
            var names = new Collection<string>("Bob", "Joe");

            Assert.That(() => names.RemoveAt(index), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");

            // Act
            names[1] = "Monika";

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Monika]"));
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var nums = new Collection<int>(10, 20, 30, 40, 50);

            Assert.That(nums.Count, Is.EqualTo(5));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_Add()
        {
            // Arrange
            var nums = new Collection<int>(10, 20, 30, 40, 50);

            // Act
            nums.Add(60);

            // Assert
            Assert.That(nums.ToString(), Is.EqualTo("[10, 20, 30, 40, 50, 60]"));
        }

        [Test]
        public void Test_Collection_ChangeItemsByIndex()
        {
            //Arrange
            var nums = new Collection<int>(10, 20, 30, 40, 50, 60);

            //Act
            nums[1] = 2000;
            nums[5] = 6000;

            //Assert
            Assert.That(nums.ToString, Is.EqualTo("[10, 2000, 30, 40, 50, 6000]"));
        }

        [Test]
        public void Test_Collection_RemoveItemFromPosition()
        {
            //Arrange 
            var nums = new Collection<int>(10, 2000, 30, 40, 50, 6000);

            //Act
            nums.RemoveAt(0);
            nums.RemoveAt(4);

            //Assert
            Assert.That(nums.ToString, Is.EqualTo("[2000, 30, 40, 50]"));
        }
        
        //DDT
        [TestCase(-1)]
        [TestCase(6)]
        public void Test_Collection_RemoveAtInvalidIndex(int index)
        {
            var nums = new Collection<int>(10, 2000, 30, 40, 50, 6000);

            Assert.That(() => nums.RemoveAt(index), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Constructor_ExchangePositions()
        {
            //Arrange
            var nums = new Collection<int>(2000, 30, 40, 50);

            //Act
            nums.Exchange(0, 1);

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[30, 2000, 40, 50]"));
        }

        [Test]
        public void Test_Collection_AddNumbers()
        {
            //Arrange
            var nums = new Collection<int>(30, 2000, 40, 50);

            //Act
            for (int i = 1; i <= 20; i++)
            {
                nums.Add(i);
            }

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[30, 2000, 40, 50, 1, 2, 3, 4, 5," +
                " 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]"));
        }

        [Test]
        public void Test_Collection_InsertAtIndex()
        {
            //Arrange
            var nums = new Collection<int>(30, 2000, 40, 50, 1, 2, 3, 4, 5, 6, 7,
                8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

            //Act
            nums.InsertAt(0, 10);
            nums.InsertAt(1, 15);

            //Assert
            Assert.That(nums.ToString, Is.EqualTo("[10, 15, 30, 2000, 40, 50, 1, 2, 3, 4, " +
                "5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]"));

            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_IsClear()
        {
            var nums = new Collection<int>();

            nums.Clear();

            Assert.That(nums, Is.Empty);
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();

            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            Assert.That(nums.Count == itemsCount);

            Assert.That(nums.Capacity >= nums.Count);

            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);

            Assert.That(nums.ToString() == "[]");

            Assert.That(nums.Capacity >= nums.Count);
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            //Arrange
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();

            var nested = new Collection<object>(names, nums, dates);

            //Act
            string nestedToString = nested.ToString();

            //Assert
            Assert.That(nestedToString,
            Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

    }
}
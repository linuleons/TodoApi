using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Controllers;
using TodoApi.Models;

namespace TestProject2
{
    [TestClass]
    public class TestTodoItemsController
    {
        TodoContext todoContext;

        public  DbContextOptions<TodoContext> dbContextOptions;
              

        [TestMethod]
        public void gettest()
        {
            // Build DbContextOptions
            dbContextOptions = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "MyToDoDb")
                .Options;

            var todoContext = new TodoContext(dbContextOptions);

            var controller = new TodoItemsController(todoContext);

            var result =(  controller.GetTodoItems()).Result.Value as List<TodoItem>;
            Assert.AreEqual(0, result.Count);

        }
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class DbInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            #region BooksInitilizer
            List<Book> books = new List<Book>(new[] { new Book
            {
                Author = "А. Шевчук",
                Description = "Книга «Design Patterns via C#» не является самостоятельным изданием, описывающим паттерны проектирования, на эту тему уже есть уникальное издание: «Приемы объектно-ориентированного проектирования.",
                Genre = "Программирование",
                Name = "Design patterns via c#",
                Price = 50
            },
            new Book
            {
                Author = "Erich Gamma",
                Description = "Capturing a wealth of experience about the design of object-oriented software, four top-notch designers present a catalog of simple and succinct solutions to commonly occurring design problems. Previously undocumented, these 23 patterns allow designers to create more flexible, elegant, and ultimately reusable designs without having to rediscover the design solutions themselves.",
                Genre = "Программирование",
                Name = "Design Patterns",
                Price = 35
            },
            new Book
            {
                Author = "Джеффри Рихтер",
                Description = "Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д.",
                Genre = "Программирование",
                Name = "CLR via C#",
                Price = 40
            },
            new Book
            {
                Author = "Adam Freeman",
                Description = "Best-selling author Adam Freeman explains how to get the most from AngularJS. He begins by describing the MVC pattern and the many benefits that can be gained from separating your logic and presentation code. He then shows how you can use AngularJS's features within in your projects to produce professional-quality results. Starting from the nuts-and-bolts and building up to the most advanced and sophisticated features AngularJS is carefully unwrapped, going in-depth to give you the knowledge you need.",
                Genre = "Программирование",
                Name = "Pro AngularJS",
                Price = 42
            },
            new Book
            {
                Author = "Robert C. Martin",
                Description = "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.",
                Genre = "Программирование",
                Name = "Clean Code",
                Price = 34
            },
            new Book
            {
                Author = "Гмурман В. Е.",
                Description = "Книга Гмурмана В. Е. описывает все основные материалы программы по теории вероятностей и математической статистике. Огромное внимание дано статистическим методам экспериментальной обработки данных. В конце главы размещены задачи с их ответами. Пригодится для студентов вузов и лиц, которые используют статистические и вероятностные методы при решении различных практических задач.",
                Genre = "Математика",
                Name = "Теория вероятностей и математическая статистика",
                Price = 38
            },
            new Book
            {
                Author = "Марк Выгодский",
                Description = "Справочник включает весь материал, входящий в программу основного курса математики высших учебных заведений. Детальная рубрикация и подробный предметный указатель позволяют читателю быстро найти необходимую информацию. Книга окажет неоценимую помощь студентам, инженерам и научным работникам.",
                Genre = "Математика",
                Name = "Справочник по высшей математике",
                Price = 46
            },
            new Book
            {
                Author = "Дональд Эрвин Кнут",
                Description = "Эта книга представляет собой том 4А, поскольку сам том 4 является многотомником. Комбинаторный поиск — богатая и важная тема, и Кнут приводит слишком много нового, интересного и полезного материала, чтобы его можно было разместить в одном или двух (а может быть, даже в трех) томах. Одна эта книга включает около 1500 упражнений с ответами для самостоятельной работы, а также сотни полезных фактов, которые вы не найдете ни в каких других публикациях. Том 4А определенно должен занять свое место на полке рядом с первыми тремя томами этой классической работы в библиотеке каждого серьезного программиста. ",
                Genre = "Алгоритмы",
                Name = "Искусство программирования. Том 4",
                Price = 42
            },
            new Book
            {
                Author = "Томас Кормен, Чарльз Лейзерсон, Рональд Ривест, Клиффорд Штайн",
                Description = "В книге Алгоритмы: построение и анализ описаны самые разнообразные алгоритмы, сочетается широкий диапазон тем с глубиной и полнотой изложения; при этом изложение доступно для читателей самого разного уровня подготовки.",
                Genre = "Алгоритмы",
                Name = "Алгоритмы. Построение и анализ",
                Price = 41
            }});
            
            books.ForEach(p => context.Books.Add(p));
            #endregion
            Role role = new Role
            {
                Code = "User",
                Name = "Пользователь",
            };
            List<Role> roles = new List<Role>();
            roles.Add(role);
            context.Roles.Add(role);
            User user = new User
            {
                Email = "test@gmail.com",
                Password = "123",
                Roles = roles,
                AddedDate = DateTime.Now,
            };
            context.Users.Add(user);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}

using HW17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Xml
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Task 1:");
      DemoTask1();
      Console.WriteLine("\n\n\n\nTask 2:");
      DemoTask2();

      Console.Read();
    }

    static void DemoTask1()
    {
      XmlDocument document = new XmlDocument();
      document.Load("https://habrahabr.ru/rss/interesting/");

      List<Item> items = new List<Item>();

      XmlElement rootElement = document.DocumentElement;
      foreach (XmlElement chanelElement in rootElement.ChildNodes)
      {
        foreach (XmlElement itemElement in chanelElement.GetElementsByTagName("item"))
        {
          XmlElement titleElement = itemElement.GetElementsByTagName("title")[0] as XmlElement;
          XmlElement linkElement = itemElement.GetElementsByTagName("link")[0] as XmlElement;
          XmlElement descriptionElement = itemElement.GetElementsByTagName("description")[0] as XmlElement;
          XmlElement pubDateElement = itemElement.GetElementsByTagName("pubDate")[0] as XmlElement;

          items.Add(new Item
          {
            Title = titleElement.InnerText,
            Link = linkElement.InnerText,
            Description = descriptionElement.InnerText,
            PubDate = pubDateElement.InnerText,
          });
        }
      }

      foreach (var item in items)
      {
        item.Description = item.Description.Replace("<br>", "");
        item.Description = item.Description.Replace("<a>", "");
        item.Description = item.Description.Replace("</a>", "");
      }

      foreach (var item in items)
      {
        Console.WriteLine($"\t\t{item.Title}\n");
        Console.WriteLine($"Ссылка: \n{item.Link}\n");
        Console.WriteLine($"Описание: \n{item.Description}\n");
        Console.WriteLine($"Дата публикации: {item.PubDate}\n\n");
      }
    }

    static void DemoTask2()
    {
      List<Student> students = new List<Student>();

      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load("Student.xml");

      XmlElement rootElement = xmlDocument.DocumentElement;
      foreach (XmlElement studentElement in rootElement)
      {
        XmlElement nameElement = studentElement.GetElementsByTagName("name")[0] as XmlElement;
        XmlElement ageElement = studentElement.GetElementsByTagName("age")[0] as XmlElement;
        XmlElement courseElement = studentElement.GetElementsByTagName("course")[0] as XmlElement;

        students.Add(new Student
        {
          Name = nameElement.InnerText,
          Age = int.Parse(ageElement.InnerText),
          Course = int.Parse(courseElement.InnerText),
        });

      }

      foreach (var student in students)
      {
        Console.WriteLine($"Имя студента: {student.Name}");
        Console.WriteLine($"Возраст студента: {student.Age}");
        Console.WriteLine($"Курс: {student.Course}\n");
      }
    }
  }
}
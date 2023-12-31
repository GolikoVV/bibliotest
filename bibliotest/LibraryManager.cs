﻿using bibliotest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotest
{
    internal class LibraryManager
    {
        private List<User> users = new List<User>();
        private List<Book> books = new List<Book>();

        public List<User> Users
        {
            get { return users; }
        }

        public List<Book> Books
        {
            get { return books; }
        }

        public User FindUser(string userName)
        {
            return users.FirstOrDefault(user => user.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public Book FindBook(string bookTitle)
        {
            return books.FirstOrDefault(book => book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        }

        public void IssueBook(User user, Book book)
        {
            if (user != null && book != null && book.Count > 0 && book.IssuedTo == null)
            {
                user.Books.Add(book);
                book.IssuedTo = user;
                book.Count--;
                book.vydana = true;
            }
        }

        public void ReturnBook(User user, Book book)
        {
            if (user != null && book != null && user.Books.Contains(book))
            {
                user.Books.Remove(book);
                book.IssuedTo = null;
                book.Count++;
            }
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
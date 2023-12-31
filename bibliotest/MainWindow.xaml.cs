﻿using bibliotest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bibliotest
{
 
    public partial class MainWindow : Window
    {
        List<User> users;
        List<Book> books;
        LibraryManager libraryManager = new LibraryManager();
        public MainWindow()
        {
            InitializeComponent();
            users = libraryManager.Users;
            books = libraryManager.Books;

        }



        private void FindBookButton_Click(object sender, RoutedEventArgs e)
        {
            Books.Items.Clear();

            string searchText = (bookTitleTextBox.Text);

            Book foundBook = libraryManager.FindBook(searchText);

            if (foundBook != null)
            {
                Books.Items.Add(foundBook);
            }
            else
            {
                MessageBox.Show("Книга не найдена.");
            }
        }

        private void FindUserButton_Click(object sender, RoutedEventArgs e)
        {
                    urs.Items.Clear();

            string searchText = (userIdTextBox.Text);

            User foundUser = libraryManager.FindUser(searchText);

            if (foundUser != null)
            {
                urs.Items.Add(foundUser);
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
            }
        }

        private void IssueBookButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser =     urs.SelectedItem as User;
            Book selectedBook = Books.SelectedItem as Book;
            if (selectedUser != null && selectedBook != null)
            {
                libraryManager.IssueBook(selectedUser, selectedBook);
                RefreshBookListView();
            }
        }

        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = urs.SelectedItem as User;
            Book returnedBook = Books.SelectedItem as Book;
            if (selectedUser != null && returnedBook != null)
            {
                libraryManager.ReturnBook(selectedUser, returnedBook);
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string family = familyTextBox.Text;

            User newUser = new User(GetNextUserId(), name, family);

            libraryManager.AddUser(newUser);

            RefreshUserListView();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            string author = authorTextBox.Text;
            string title = titleTextBox.Text;
            int count;
            if (int.TryParse(countTextBox.Text, out count))
            {
                int Acr;
                if (int.TryParse(arcTextBox.Text, out Acr))
                {
                    Book newBook = new Book(title, author, count, Acr);
                    libraryManager.AddBook(newBook);
                    RefreshBookListView();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное числовое значение в поле 'Дата'.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение в поле 'Количество'.");
            }
        }




        private void RefreshUserListView()
        {
            urs.Items.Clear();

            foreach (User user in libraryManager.Users)
            {
                urs.Items.Add(user);
            }

        }

        private void RefreshBookListView()
        {
            Books.Items.Clear();

            foreach (Book book in libraryManager.Books)
            {
                Books.Items.Add(book);
            }
        }

        private int nextUserId = 1;

        private int GetNextUserId()
        {
            return nextUserId++;
        }

        private void Filter()
        {
            Books.Items.Clear();
            foreach (Book book in libraryManager.Books)
            {
                if (book.vydana == true)
                    Books.Items.Add(book);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RefreshBookListView();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
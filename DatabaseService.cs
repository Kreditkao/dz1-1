using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;
using ConsoleApp2.Models;

namespace ConsoleApp2;

public class DatabaseService
{
    private readonly string _connectionString = "Server=DESKTOP-KGIM8M1\\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public void AddAdmin()
    {
        using var connection = new SqlConnection(_connectionString);
        string query = "INSERT INTO Products (Name, Price) VALUES ('Admin', 1234)";
        connection.Execute(query);
    }

    public bool Authenticate(string username, string password)
    {
        using var connection = new SqlConnection(_connectionString);
        string query = "SELECT COUNT(*) FROM Products WHERE Name = @Username AND Price = @Password";
        int userCount = connection.ExecuteScalar<int>(query, new { Username = username, Password = decimal.Parse(password) });

        return userCount > 0;
    }

    public void AddStudent(string name, int age, string email)
    {
        using var connection = new SqlConnection(_connectionString);
        string query = "INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)";
        connection.Execute(query, new { Name = name, Age = age, Email = email });
    }

    public IEnumerable<Student> GetStudents()
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.Query<Student>("SELECT * FROM Students");
    }

    public void UpdateStudent(int id, string name, int age, string email)
    {
        using var connection = new SqlConnection(_connectionString);
        string query = "UPDATE Students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id";
        connection.Execute(query, new { Id = id, Name = name, Age = age, Email = email });
    }

    public void DeleteStudent(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        string query = "DELETE FROM Students WHERE Id = @Id";
        connection.Execute(query, new { Id = id });
    }
}

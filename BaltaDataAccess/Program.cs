﻿using System;
using BaltaDataAccess.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";
            using (var connection = new SqlConnection(connectionString))
            {
                // UpdateCategory(connection);
                // ListCategories(connection);
                // CreateCategory(connection);
                // ExecuteProcedure(connection);
                // ExecuteReadProcedure(connection);
                // ExecuteScalar(connection);
                ReadView(connection);
            }
        }

        public static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id],[Title] FROM [Category]");
            foreach (var c in categories)
            {
                System.Console.WriteLine($"{c.Id} - {c.Title}");
            }
        }

        public static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();

            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            const string insertSql = @"
            INSERT INTO [Category]
            VALUES (
                @Id,
                @Title,
                @Url,
                @Summary,
                @Order,
                @Description,
                @Featured
            )";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            System.Console.WriteLine($"{rows} linhas inseridas.");
        }
        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend 2022"
            });

            System.Console.WriteLine();
            System.Console.WriteLine($"{rows} registros atualizadas");
            System.Console.WriteLine();
        }
        static void ExecuteProcedure(SqlConnection connection)
        {
            var sql = "[spDeleteStudent]";
            var pars = new { StudentId = "79b82071-80a8-4e78-a79c-92c8cd1fd052" };

            var affectedRows = connection.Execute(
                sql,
                pars,
                commandType: System.Data.CommandType.StoredProcedure
            );

            System.Console.WriteLine($"{affectedRows} linhas afetadas");
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var sql = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };

            var courses = connection.Query(
                sql,
                pars,
                commandType: System.Data.CommandType.StoredProcedure
            );

            foreach (var c in courses)
            {
                System.Console.WriteLine(c.Id);
            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {

            var category = new Category();

            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            const string insertSql = @"
            INSERT INTO [Category]
            OUTPUT inserted.[Id]
            VALUES (
                NEWID(),
                @Title,
                @Url,
                @Summary,
                @Order,
                @Description,
                @Featured
            )";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                // category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            System.Console.WriteLine($"A categoria inserida foi: {id}.");
        }


        public static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query(sql);
            foreach (var c in courses)
            {
                System.Console.WriteLine($"{c.Id} - {c.Title}");
            }
        }
    }
}

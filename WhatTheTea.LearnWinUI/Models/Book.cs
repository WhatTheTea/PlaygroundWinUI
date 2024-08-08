namespace WhatTheTea.LearnWinUI.Models
{
    public enum BookType
    {
        Paperback,
        Hardcover,
        Digital
    }
    
    public record Book(string Title, string Authors, BookType Type, int YearOfPublish);
}

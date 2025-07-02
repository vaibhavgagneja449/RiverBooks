﻿using FastEndpoints;
using FastEndpoints.Testing;
using RiverBooks.Books.BookEndpoints;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookList(Fixture fixture) : TestBase<Fixture>
{
  [Fact]
  public async Task ReturnsBooksAsync()
  {
    var testResult = await fixture.Client.GETAsync<List, ListBooksResponse>();

    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Books.Count.ShouldBe(3);
  }
}

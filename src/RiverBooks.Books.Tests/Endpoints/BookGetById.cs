﻿using FastEndpoints;
using FastEndpoints.Testing;
using RiverBooks.Books.BookEndpoints;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookGetById(Fixture fixture) : TestBase<Fixture>
{
  [Theory]
  [InlineData("A89F6CD7-4693-457B-9009-02205DBBFE45", "The Fellowship of the Ring")]
  [InlineData("E4FA19BF-6981-4E50-A542-7C9B26E9EC31", "The Two Towers")]
  [InlineData("17C61E41-3953-42CD-8F88-D3F698869B35", "The Return of the King")]
  public async Task ReturnsBooksForKnownIdsAsync(string validId, string expectedTitle)
  {
    Guid id = Guid.Parse(validId);
    var request = new GetByIdRequest { Id = id };
    var testResult = await fixture.Client.GETAsync<GetById, GetByIdRequest, BookDto>(request);

    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Title.ShouldBe(expectedTitle);
  }
}

using Microsoft.EntityFrameworkCore;
//*Create a static class to contain house related endpoints
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;
public static class WebApplicationBidExtensions 
{
  //*In it we define an extension method for the WebApplication type.
  //*the variable is "app" we have neen using all along in Program.cs is of that type.
  //*Copy MapGet, MapPost, MapPut, MapDelete from program.cs
  public static void MapBidEndpoints(this WebApplication app)
  {
     //*=================================
   //*BidEntity endpoints 
   //*=================================

   //*The first parameter is the url to bids table. Use the "house" as the base and then add "bids"
   //*The second parameter we ask DEPENDENCY INJECTOR CONTAINER for IHouseRepository and IBidRepository we ask 
  // app.MapGet("/house/{houseId:int}/bids", async(
  //          int houseId,
  //          IHouseRepository houseRepo, 
  //          IBidRepository bidRepo) =>
  //  {
  //     if (await houseRepo.Get(houseId) == null) //*The house entity doesn't exist
  //        return Results.Problem($"House with ID {houseId} not found.",
  //             statusCode: 404);

  //     //*Else
  //     var bids = await bidRepo.Get(houseId); //*get the DTO 
  //     return Results.Ok(bids);
    
  //  }).ProducesProblem(404).Produces(StatusCodes.Status200OK);


  //*Post
//   app.MapPost("/house/{houseId:int}/bids", 
//     async (int houseId, [FromBody] BidDto dto, IBidRepository repo) => 
// {   
//     if (dto.HouseId != houseId) //* Is there a houseId mismatch?
//         return Results.Problem($"House Id of DTO {dto.HouseId} doesn't match with URL data {houseId}", 
//             statusCode: StatusCodes.Status400BadRequest);
//     if (!MiniValidator.TryValidate(dto, out var errors))
//         return Results.ValidationProblem(errors);
//     var newBid = await repo.Add(dto);

//     //*return where new bid can be found: "/houses/{newBid.HouseId}/bids"
//     return Results.Created($"/houses/{newBid.HouseId}/bids", newBid);

// }).ProducesValidationProblem()
//   .ProducesProblem(400)
//   .Produces<BidDto>(StatusCodes.Status201Created);

        //     app.MapPost("/house/{houseId:int}/bids", 
        //    async (int houseId, [FromBody] BidDto dto, IBidRepository repo) => 
        // {   
        //     if (dto.HouseId != houseId)
        //         return Results.Problem($"House Id of DTO {dto.HouseId} doesn't match with URL data {houseId}", 
        //             statusCode: StatusCodes.Status400BadRequest);
        //     if (!MiniValidator.TryValidate(dto, out var errors))
        //         return Results.ValidationProblem(errors);
        //     var newBid = await repo.Add(dto);
        //     return Results.Created($"/houses/{newBid.HouseId}/bids", newBid);
        // }).ProducesValidationProblem().ProducesProblem(400).Produces<BidDto>(StatusCodes.Status201Created);


  }
}
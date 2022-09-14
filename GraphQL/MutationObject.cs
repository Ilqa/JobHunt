using System;
using BooksBot.API.Services;
using GraphQL;
using GraphQL.Types;
using MovieReviews.Database;
using MovieReviews.GraphQL.Types;
using MovieReviews.Models;

namespace MovieReviews.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IMovieRepository repository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";

            FieldAsync<MovieObject, Movie>(
                "addReview",
                "Add review to a movie.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique GUID of the movie."
                    },
                    new QueryArgument<NonNullGraphType<ReviewInputObject>>
                    {
                        Name = "review",
                        Description = "Review for the movie."
                    }),
                context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var review = context.GetArgument<Review>("review");
                    return repository.AddReviewToMovieAsync(id, review);
                });
        }

        //public async string Login(IIdentityService repository)
        //{
        //    Name = "Login";
        //    Description = "The base mutation for all the entities in our object graph.";

        //    FieldAsync<MovieObject, Movie>(
        //        "addReview",
        //        "Add review to a movie.",
        //        new QueryArguments(
        //            new QueryArgument<NonNullGraphType<IdGraphType>>
        //            {
        //                Name = "id",
        //                Description = "The unique GUID of the movie."
        //            },
        //            new QueryArgument<NonNullGraphType<ReviewInputObject>>
        //            {
        //                Name = "review",
        //                Description = "Review for the movie."
        //            }),
        //        async context =>
        //        {
        //            var id = context.GetArgument<string>("email");
        //            var review = context.GetArgument<string>("password");
        //            return await repository.Login(id, review);
        //        });
        //}
    }

}
using ITOps.Composition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricingCalculator
{
    public class PriceProvider : IProvideData
    {
        public bool Matches(RouteData routeData, HttpRequest request)
        {
            var controller = ((string)routeData.Values["controller"]).ToLowerInvariant();
            var action = ((string)routeData.Values["action"]).ToLowerInvariant();

            return controller == "data" && request.Query.ContainsKey("moviedetails");
        }

        public Task PopulateData(dynamic viewModel, RouteData routeData, HttpRequest request)
        {
            var moviePrices = new Dictionary<string, decimal>
            {
                { "black panther", 30.701754385964912280701754385965m },
                { "star wars: the last jedi", 33.333333333333333333333333333333m },
                { "inxeba", 26.315789473684210526315789473684m },
                { "animal farm", 21.929824561403508771929824561404m },
                { "nun's on the run", 15.789473684210526315789473684211m },
                { "pitch perfect 3", 13.157894736842105263157894736842m },
            };

            var movieId = request.Query["moviedetails"].ToString().ToLowerInvariant();

            viewModel.totalPrice = moviePrices[movieId] * 1.15m;

            return Task.CompletedTask;
        }
    }
}
﻿using NUnit.Framework;
using OpenAI.Images;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Tests
{
    internal class TestFixture_05_Images : AbstractTestFixture
    {
        [Test]
        public async Task Test_1_GenerateImages()
        {
            Assert.IsNotNull(OpenAIClient.ImagesEndPoint);

            var results = await OpenAIClient.ImagesEndPoint.GenerateImageAsync("A house riding a velociraptor", 1, ImageSize.Small);

            Assert.IsNotNull(results);
            Assert.NotZero(results.Count);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        [Test]
        public async Task Test_2_GenerateImageEdits()
        {
            Assert.IsNotNull(OpenAIClient.ImagesEndPoint);

            var imageAssetPath = Path.GetFullPath("..\\..\\..\\Assets\\image_edit_original.png");
            var maskAssetPath = Path.GetFullPath("..\\..\\..\\Assets\\image_edit_mask.png");

            var results = await OpenAIClient.ImagesEndPoint.CreateImageEditAsync(imageAssetPath, maskAssetPath, "A sunlit indoor lounge area with a pool containing a flamingo", 1, ImageSize.Small);

            Assert.IsNotNull(results);
            Assert.NotZero(results.Count);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        [Test]
        public async Task Test_3_GenerateImageVariations()
        {
            Assert.IsNotNull(OpenAIClient.ImagesEndPoint);

            var imageAssetPath = Path.GetFullPath("..\\..\\..\\Assets\\image_edit_original.png");

            var results = await OpenAIClient.ImagesEndPoint.CreateImageVariationAsync(imageAssetPath, 1, ImageSize.Small);

            Assert.IsNotNull(results);
            Assert.NotZero(results.Count);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}

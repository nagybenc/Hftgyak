using M10FB1_HFT_2022232.Logic;
using M10FB1_HFT_2022232.Models;
using M10FB1_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Test
{
    [TestFixture]
    public class Tester
    {
        LabelLogic labelLogic;
        AlbumLogic albumLogic;
        ArtistLogic artistLogic;

        [SetUp]
        public void Setup()
        {
            Mock<IRepository<Label>> mockLabelRepo = new Mock<IRepository<Label>>();
            Mock<IRepository<Album>> mockAlbumRepo = new Mock<IRepository<Album>>();
            Mock<IRepository<Artist>> mockArtistRepo = new Mock<IRepository<Artist>>();


        }


    }
}

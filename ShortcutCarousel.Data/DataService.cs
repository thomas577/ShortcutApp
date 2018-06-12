using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Model;
using System.ComponentModel.Composition;

namespace ShortcutCarousel.Data
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        private ICarouselUserRepository carouselUserRepository;

        [ImportingConstructor]
        public DataService(ICarouselUserRepository carouselUserRepository)
        {
            this.carouselUserRepository = carouselUserRepository;
        }

        public IList<string> GetAllUserNames()
        {
            return this.carouselUserRepository.GetAllNames();
        }

        public ICarouselUser LoadUserByName(string name)
        {
            return this.carouselUserRepository.GetByName(name);
        }

        public void SaveUser(ICarouselUser user)
        {
            this.carouselUserRepository.Save(user);
        }
    }
}

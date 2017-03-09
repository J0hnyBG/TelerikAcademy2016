using System.Web.Mvc;

using ByteSizeLib;

using _02_MVC_Essentials.Enums;
using _02_MVC_Essentials.Models;

namespace _02_MVC_Essentials.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Index(ByteCalculatorBindingModel model)
        {
            var quantity = model.Quantity;
            var multiple = model.Multiple;
            var kiloByteSize = model.KiloByteSize;

            if (kiloByteSize == 1024)
            {
                return this.FromLongBytes(quantity, multiple);
            }

            return this.FromShortBytes(quantity, multiple);
        }

        private ActionResult FromLongBytes(long quantity, ByteMultiple multiple)
        {
            ByteSize calculatedSize;
            switch (multiple)
            {
                case ByteMultiple.Byte:
                    calculatedSize = ByteSize.FromBytes(quantity);
                    break;
                case ByteMultiple.KiloByte:
                    calculatedSize = ByteSize.FromKiloBytes(quantity);
                    break;
                case ByteMultiple.MegaByte:
                    calculatedSize = ByteSize.FromMegaBytes(quantity);
                    break;
                case ByteMultiple.GigaByte:
                    calculatedSize = ByteSize.FromGigaBytes(quantity);
                    break;
                case ByteMultiple.TeraByte:
                    calculatedSize = ByteSize.FromTeraBytes(quantity);
                    break;
                case ByteMultiple.PetaByte:
                    calculatedSize = ByteSize.FromPetaBytes(quantity);
                    break;
                default:
                    calculatedSize = ByteSize.FromBits(quantity);
                    break;
            }

            var viewModel = new ByteCalculatorViewModel();
            viewModel.Results.Add(ByteMultiple.Bit.ToString(), calculatedSize.Bits.ToString());
            viewModel.Results.Add(ByteMultiple.Byte.ToString(), calculatedSize.Bytes.ToString());
            viewModel.Results.Add(ByteMultiple.KiloByte.ToString(), calculatedSize.KiloBytes.ToString());
            viewModel.Results.Add(ByteMultiple.MegaByte.ToString(), calculatedSize.MegaBytes.ToString());
            viewModel.Results.Add(ByteMultiple.GigaByte.ToString(), calculatedSize.GigaBytes.ToString());
            viewModel.Results.Add(ByteMultiple.TeraByte.ToString(), calculatedSize.TeraBytes.ToString());
            viewModel.Results.Add(ByteMultiple.PetaByte.ToString(), calculatedSize.PetaBytes.ToString());

            return this.PartialView("_CalculatorResults", viewModel);
        }

        private ActionResult FromShortBytes(long quantity, ByteMultiple multiple)
        {
            ShortByteSize calculatedSize;
            switch (multiple)
            {
                case ByteMultiple.Byte:
                    calculatedSize = ShortByteSize.FromBytes(quantity);
                    break;
                case ByteMultiple.KiloByte:
                    calculatedSize = ShortByteSize.FromKiloBytes(quantity);
                    break;
                case ByteMultiple.MegaByte:
                    calculatedSize = ShortByteSize.FromMegaBytes(quantity);
                    break;
                case ByteMultiple.GigaByte:
                    calculatedSize = ShortByteSize.FromGigaBytes(quantity);
                    break;
                case ByteMultiple.TeraByte:
                    calculatedSize = ShortByteSize.FromTeraBytes(quantity);
                    break;
                case ByteMultiple.PetaByte:
                    calculatedSize = ShortByteSize.FromPetaBytes(quantity);
                    break;
                default:
                    calculatedSize = ShortByteSize.FromBits(quantity);
                    break;
            }

            var viewModel = new ByteCalculatorViewModel();
            viewModel.Results.Add(ByteMultiple.Bit.ToString(), calculatedSize.Bits.ToString());
            viewModel.Results.Add(ByteMultiple.Byte.ToString(), calculatedSize.Bytes.ToString());
            viewModel.Results.Add(ByteMultiple.KiloByte.ToString(), calculatedSize.KiloBytes.ToString());
            viewModel.Results.Add(ByteMultiple.MegaByte.ToString(), calculatedSize.MegaBytes.ToString());
            viewModel.Results.Add(ByteMultiple.GigaByte.ToString(), calculatedSize.GigaBytes.ToString());
            viewModel.Results.Add(ByteMultiple.TeraByte.ToString(), calculatedSize.TeraBytes.ToString());
            viewModel.Results.Add(ByteMultiple.PetaByte.ToString(), calculatedSize.PetaBytes.ToString());

            return this.PartialView("_CalculatorResults", viewModel);
        }
    }
}

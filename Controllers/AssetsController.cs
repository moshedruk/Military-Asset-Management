using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Military_Asset_Management_System.Military_modles;

namespace Military_Asset_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        //private static List<Vehicle> _vehicles = new List<Vehicle>();
        //private static List<Vehicle> _weapons = new List<Vehicle>();
        //private static List<Vehicle> _personnel = new List<Vehicle>();

        public static List<Vehicle> Vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                Name = "Humvee",
                AssetType = "Vehicle",
                Status = "Active",
                Model = "M998",
                LicensePlate = "123-ABC",
                OperationalStatus = "Operational"
            },
            new Vehicle
            {
                Id = 2,
                Name = "Tank",
                AssetType = "Vehicle",
                Status = "Active",
                Model = "M1 Abrams",
                LicensePlate = "456-DEF",
                OperationalStatus = "Operational"
            }
        };

        public static List<Weapon> Weapons = new List<Weapon>
        {
            new Weapon
            {
                Id = 1,
                Name = "M16 Rifle",
                AssetType = "Weapon",
                Status = "Active",
                Caliber = "5.56mm",
                SerialNumber = "789-GHI",
                AmmunitionCount = 120
            },
            new Weapon
            {
                Id = 2,
                Name = "Glock 19",
                AssetType = "Weapon",
                Status = "Inactive",
                Caliber = "9mm",
                SerialNumber = "012-JKL",
                AmmunitionCount = 45
            }
        };

        public static List<Personnel> PersonnelList = new List<Personnel>
        {
            new Personnel
            {
                Id = 1,
                Name = "John Doe",
                AssetType = "Personnel",
                Status = "Active",
                Rank = "Sergeant",
                ServiceNumber = "567-MNO",
                AssignedUnit = "Infantry"
            },
            new Personnel
            {
                Id = 2,
                Name = "Jane Smith",
                AssetType = "Personnel",
                Status = "Inactive",
                Rank = "Lieutenant",
                ServiceNumber = "890-PQR",
                AssignedUnit = "Logistics"
            }
        };
        [HttpGet("{id}")]
        public ActionResult<BaseAsset> GetById(int id, string type)
        {
            BaseAsset asset = null;
            switch (type.ToLower())
            {
                case "vehicle":
                    asset = Vehicles.FirstOrDefault(v => v.Id == id);
                    break;
                case "weapon":
                    asset = Weapons.FirstOrDefault(w => w.Id == id);
                    break;
                case "personnel":
                    asset = PersonnelList.FirstOrDefault(p => p.Id == id);
                    break;
                default:
                    return BadRequest("Invalid asset type");
            }

            if (asset == null)
                return NotFound();

            return Ok(asset);
        }

        [HttpGet("type/{type}")]
        public ActionResult<IEnumerable<BaseAsset>> Get(string type)
        {
            switch (type.ToLower())
            {
                case "vehicle":
                    return Ok(Vehicles.ToArray());
                case "weapon":
                    return Ok(Weapons.ToArray());
                case "personnel":
                    return Ok(PersonnelList.ToArray());
                default:
                    return BadRequest("Invalid asset type");
            }
        }
        [HttpPost("vehicle")]
        public ActionResult<Vehicle> CreateVehicle([FromBody] Vehicle newVehicle)
        {
            if (newVehicle == null)
                return BadRequest("Vehicle data is null");

            Vehicles.Add(newVehicle);
            return CreatedAtAction(nameof(GetById), new { id = newVehicle.Id, type = "vehicle" }, newVehicle);
        }
        [HttpPost("weapon")]
        public ActionResult<Weapon> CreatWeapons([FromBody] Weapon newWeapons)
        {
            if (newWeapons == null) 
            {
                return BadRequest("Weapon data is null");
            }

            Weapons.Add(newWeapons);
            return CreatedAtAction("GetById", new { id = newWeapons.Id, type = "weapon" });
        }

    }
   
}

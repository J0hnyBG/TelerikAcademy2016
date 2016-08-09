using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.MockedClasses
{
    public class MockedTeleportStation : TeleportStation
    {
        public MockedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) 
            : base(owner, galacticMap, location)
        {

        }

        public IEnumerable<IPath> GalacticMap { get { return this.galacticMap; } }
        public IResources Resources { get { return this.resources; } }
        public IBusinessOwner Owner { get { return this.owner; } }
        public ILocation Location { get { return this.location; } }
    }
}

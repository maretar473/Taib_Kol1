using MT_Kol_Term_1.DTO;
using MT_Kol_Term_1.Model;

namespace MT_Kol_Term_1.BLL
{
    public class MouseService:IMouseService
    {
        private static readonly List<Mouse> _mice = new()
        {
            new Mouse { ID = 1, Model = "Logitech G502", DPI = 16000 },
            new Mouse { ID = 2, Model = "Razer DeathAdder", DPI = 20000 },
            new Mouse { ID = 3, Model = "SteelSeries Rival 600", DPI = 12000 },
            new Mouse { ID = 4, Model = "Corsair M65 Elite", DPI = 18000 },
            new Mouse { ID = 5, Model = "Zowie FK2", DPI = 3200 },
            new Mouse { ID = 6, Model = "Glorious Model O", DPI = 12000 },
            new Mouse { ID = 7, Model = "Logitech MX Master 3", DPI = 4000 },
            new Mouse { ID = 8, Model = "Cooler Master MM710", DPI = 16000 }
        };

        private static int _nextId = 9;

        public IEnumerable<MouseResponseDTO> GetMice()
        {
            return _mice.Select(x => ToMouseResponseDTO(x));
        }

        public MouseResponseDTO GetMouse(int id)
        {
            var mouse = FindMouse(id);
            return ToMouseResponseDTO(mouse);
        }

        public void DeleteMouse(int id)
        {
            var mouse = FindMouse(id);
            _mice.Remove(mouse);
        }

        public void PutMouse(int id, MouseRequestDTO mouseRequestDTO)
        {
            var mouse = FindMouse(id);
            mouse.Model = mouseRequestDTO.Model;
            mouse.DPI = mouseRequestDTO.DPI;
        }

        public void PostMouse(MouseRequestDTO mouseRequestDTO)
        {
            var mouse = new Mouse
            {
                ID = _nextId++,
                Model = mouseRequestDTO.Model,
                DPI = mouseRequestDTO.DPI
            };
            _mice.Add(mouse);
        }

        private Mouse FindMouse(int id)
        {
            var mouse = _mice.Find(x => x.ID == id);
            if (mouse == null)
            {
                throw new Exception($"Mouse with ID {id} not found.");
            }

            return mouse;
        }

        private MouseResponseDTO ToMouseResponseDTO(Mouse mouse)
        {
            return new MouseResponseDTO
            {
                ID = mouse.ID,
                Model = mouse.Model,
                DPI = mouse.DPI
            };
        }
    }
}

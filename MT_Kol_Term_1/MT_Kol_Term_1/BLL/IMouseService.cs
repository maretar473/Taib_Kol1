using MT_Kol_Term_1.DTO;
using MT_Kol_Term_1.Model;

namespace MT_Kol_Term_1.BLL
{
    public interface IMouseService
    {
        IEnumerable<MouseResponseDTO> GetMice();
        MouseResponseDTO GetMouse(int id);
        void DeleteMouse(int id);
        void PutMouse(int id, MouseRequestDTO mouseRequestDTO);
        void PostMouse(MouseRequestDTO mouseRequestDTO);
    }
}

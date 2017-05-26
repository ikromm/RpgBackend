using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ikromm.Ui
{
    public class RenovateDialog : MonoBehaviour // This should be a Dialog in final version
    {
        public GameObject RoomPrefab;

        [Header("Containers")]
        public Button UpgradeButton;
        public Transform RoomsContainer;
        public Text GoldRequirements;
        public Text ShardsRequirements;

        public List<Castle.Room> Rooms;

        private List<Room> rooms;
        private Room selectedRoom;

        public void Start()
        {
            foreach (Castle.Room room in Rooms)
                CreateRoom(room).transform.SetParent(RoomsContainer, false);
        }

        private GameObject CreateRoom(Castle.Room castleRoom)
        {
            GameObject instance = Instantiate(RoomPrefab);
            Room script = instance.GetComponent<Room>();
            script.CastleRoom = castleRoom;

            Button button = instance.AddComponent<Button>();
            button.onClick.AddListener(() => SelectRoom(script));

            return instance;
        }

        public void SelectRoom(Room newRoom)
        {
            if (selectedRoom != null)
                selectedRoom.Selected = false;

            selectedRoom = newRoom;
            selectedRoom.Selected = true;

            UpdateCost();
        }

        private void UpdateCost()
        {
            GoldRequirements.text = selectedRoom.CastleRoom.LevelRequirements
                .Where(x => x.Level == (selectedRoom.CastleRoom.Level + 1))
                .First(x => x.RequiredItem.Type == Items.Types.Gold).Quantity.ToString();

            ShardsRequirements.text = selectedRoom.CastleRoom.LevelRequirements
                .Where(x => x.Level == (selectedRoom.CastleRoom.Level + 1))
                .First(x => x.RequiredItem.Type == Items.Types.Material).Quantity.ToString();
        }
    }
}
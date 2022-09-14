using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaLib.DAL
{
    public interface IRepo
   {
        //      Apartment
        IList<Apartment> GetAllApartments();
        Apartment GetApartmentByID(int id);
        IList<Apartment> GetAllApartmentsByStatusId(int? statusId);
        void CreateApartment(Apartment apartment);
        void UpdateApartment(Apartment apartment);
        void DeleteApartment(int apartmentId);
        int GetApartmentId(string apartmentName, string address, int? rooms, int? adults, int? children);

        //      Tags
        IList<Tag> LoadAllTags();
        string GetTypeNameEng(int tagID);
        int GetUsedTags(int tagID);
        IList<Tag> GetTags();
        IList<string> LoadAllTagTypes();
        IList<Tag> GetApartmentTags(int apartmentId);
        void AddNewTag(int typeID, string nameEng);
        void DeleteTag(int tagId);
        void DeleteApartmentTagByID(int tagID, int apartmentID);
        void AddNewTagToApartment(int tagID, int apartmentID);
        IList<Tag> GetUnusedTagsOnApartment(int apartmentId);

        //      User
        IList<User> GetAllUsers();
        User GetUserByID(int userId);
        User GetUnregisteredUser(int apartmentId);
        User AuthUser(string username, string password);
        void CreateUser(User u);

        //      Reservation
        void CreateApartmentReservationById(int registeredUserId, int apartmentId, string details);
        void CreateApartmentReservation(int apartmentId, string username, string email, string phonenumber, string address, string details);
        void DeleteApartmentReservation(int apartmentId);
        void UpdateApartmentReservation(int apartmentId, string details, string userName, string phoneNumber, string email, string address);
        void UpdateApartmentReservationByUserId(int apartmentId, string details, int registeredUserId);

        //      Statuses
        int GetApartmentStatus(int apartmentId);
        IList<Status> GetStatuses();

        //      City
        City GetCityByID(int id);
        IList<City> GetAllCities();

        //      Owner
        ApartmentOwner GetApartmentOwnerById(int apartmentId);
        IList<ApartmentOwner> GetApartmentOwners();
        ApartmentOwner GetApartmentOwnerByApartmentId(int ownerId);

        //      Pictures
        IList<ApartmentPicture> GetApartmentPictures();
        IList<ApartmentPicture> GetApartmentPicturesByID(int apartmentId);
        void AddPictures(int apartmentId, string path);
        int GetNumberOfApartmentPictures(int apartmentId);
        void SetRepresentativePicture(int newRepresentative, int oldRepresentative);
        void DeleteApartmentPictureByID(int imageid);        
        string GetImagePath(int imageId);

        // Reservation
        void CreateNewPublicReservation(Reservation reservation);

        // Review
        void CreateNewReview(Review review);
        int GetReview(int apartmentId);
    }
}

using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace RwaLib.DAL
{
    public class DBRepo : IRepo
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        //      APARTMENTS

        public IList<Apartment> GetAllApartments()
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(CS, nameof(GetAllApartments)).Tables[0];
            if (tblApartments.Rows.Count == 0) return null;

            for (int i = 0; i < tblApartments.Rows.Count; i++)
            {
                DataRow row = tblApartments.Rows[i];
                apartments.Add(new Apartment
                {
                    Id = (int)row[nameof(Apartment.Id)],
                    Name = row[nameof(Apartment.NameEng)].ToString(),
                    NameEng = row[nameof(Apartment.NameEng)].ToString(),
                    MaxAdults = (int)row[nameof(Apartment.MaxAdults)],
                    MaxChildren = (int)row[nameof(Apartment.MaxChildren)],
                    TotalRooms = (int)row[nameof(Apartment.TotalRooms)],
                    Price = (int)row[nameof(Apartment.Price)],
                    StatusId = (int)row[nameof(Apartment.StatusId)],
                    BeachDistance = (int)row[nameof(Apartment.BeachDistance)],
                    City = GetCityByID((int)row[nameof(Apartment.CityId)]),
                    Status = GetStatuses((int)row[nameof(Apartment.StatusId)]),
                    NumberOfPictures = GetNumberOfApartmentPictures((int)row[nameof(Apartment.Id)]),
                    Review = GetReview((int)row[nameof(Apartment.Id)])
                });
            }

            return apartments;
        }
                

        public Apartment GetApartmentByID(int id)
        {
            Apartment apartment = new Apartment();

            var tblApartment = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentByID), id).Tables[0];
            if (tblApartment.Rows.Count == 0) return null;

            DataRow row = tblApartment.Rows[0];

            apartment.Id = (int)row[nameof(Apartment.Id)];
            apartment.NameEng = row[nameof(Apartment.NameEng)].ToString();
            apartment.MaxAdults = (int)row[nameof(Apartment.MaxAdults)];
            apartment.MaxChildren = (int)row[nameof(Apartment.MaxChildren)];
            apartment.TotalRooms = (int)row[nameof(Apartment.TotalRooms)];
            apartment.Price = (int)row[nameof(Apartment.Price)];
            apartment.City = GetCityByID((int)row[nameof(Apartment.CityId)]);
            apartment.StatusId = (int)row[nameof(Apartment.StatusId)];
            apartment.Status = GetStatuses((int)row[nameof(Apartment.StatusId)]);
            apartment.BeachDistance = (int)row[nameof(Apartment.BeachDistance)];
            apartment.Address = row[nameof(Apartment.Address)].ToString();
            apartment.OwnerId = (int)row[nameof(Apartment.OwnerId)];
            apartment.Review = GetReview(apartment.Id);

            return apartment;
        }
               

        public IList<Apartment> GetAllApartmentsByStatusId(int? statusId)
        {
            IList<Apartment> apartments = new List<Apartment>();
            DataTable tblApartments;
            if (statusId.HasValue && statusId.Value != 0)
            {
                tblApartments = SqlHelper.ExecuteDataset(CS, nameof(GetAllApartmentsByStatusId), statusId).Tables[0];

                if (tblApartments == null) return null;

                for (int i = 0; i < tblApartments.Rows.Count; i++)
                {
                    DataRow row = tblApartments.Rows[i];
                    apartments.Add(new Apartment
                    {
                        Id = (int)row[nameof(Apartment.Id)],
                        NameEng = row[nameof(Apartment.NameEng)].ToString(),
                        MaxAdults = (int)row[nameof(Apartment.MaxAdults)],
                        MaxChildren = (int)row[nameof(Apartment.MaxChildren)],
                        TotalRooms = (int)row[nameof(Apartment.TotalRooms)],
                        Price = (int)row[nameof(Apartment.Price)],
                        BeachDistance = (int)row[nameof(Apartment.BeachDistance)],
                        City = GetCityByID((int)row[nameof(Apartment.CityId)]),
                        Status = GetStatuses((int)row[nameof(Apartment.StatusId)])

                    });
                }
            }

            return apartments;
        }


        public void CreateApartment(Apartment apartment)
        {           
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateApartment), apartment.NameEng, apartment.Price, apartment.MaxAdults, apartment.MaxChildren, apartment.TotalRooms, apartment.BeachDistance, apartment.CityId, apartment.OwnerId, apartment.Address, apartment.StatusId);
        }


        public void UpdateApartment(Apartment apartment)
        {
            SqlHelper.ExecuteDataset(CS, nameof(UpdateApartment), apartment.NameEng, apartment.MaxChildren, apartment.MaxAdults, apartment.BeachDistance, apartment.Price, apartment.StatusId, apartment.OwnerId, apartment.TotalRooms, apartment.Id,apartment.Address);
        }       


        public void DeleteApartment(int apartmentId)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartment), apartmentId);
        }


        public int GetApartmentId(string apartmentName, string address, int? rooms, int? adults, int? children)
        {
            Apartment apartment = new Apartment();

            var tblApartment = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentId), apartmentName, address, rooms, adults, children).Tables[0];
            if (tblApartment.Rows.Count == 0) return 0;

            DataRow row = tblApartment.Rows[0];

            return (int)row[nameof(Apartment.Id)];
        }

        ////////////////////////////////////////////////////////



        //      TAGS

        public IList<Tag> LoadAllTags()
        {
            IList<Tag> tags = new List<Tag>();

            var tblTags = SqlHelper.ExecuteDataset(CS, nameof(LoadAllTags)).Tables[0];
            if (tblTags == null) return null;


            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(new Tag
                {
                    Id = (int)row[nameof(Tag.Id)],
                    TagTypeID = (int)row[nameof(Tag.TagTypeID)],
                    NameEng = row[nameof(Tag.NameEng)].ToString(),
                    TagTypeName = row[nameof(Tag.TagTypeName)].ToString()
                });
            }

            foreach (Tag tag in tags)
            {
                tag.TagTypeNameEng = GetTypeNameEng(tag.TagTypeID);
            }

            foreach (Tag tag in tags)
            {
                tag.Used = GetUsedTags(tag.Id);
            }

            return tags;
        }
        

        public string GetTypeNameEng(int tagID)
        {
            var tblTag = SqlHelper.ExecuteDataset(CS, nameof(GetTypeNameEng), tagID).Tables[0];
            if (tblTag.Rows.Count == 0) return null;
            DataRow row = tblTag.Rows[0];

            return row[nameof(Tag.NameEng)].ToString();
        }


        public int GetUsedTags(int tagID)
        {
            var tblUsed = SqlHelper.ExecuteDataset(CS, nameof(GetUsedTags), tagID).Tables[0];
            if (tblUsed.Rows.Count == 0) return 0;

            DataRow row = tblUsed.Rows[0];

            return (int)(row[nameof(Tag.Used)]);
        }


        public IList<Tag> GetTags()
        {
            var tblTags = SqlHelper.ExecuteDataset(CS, nameof(GetTags)).Tables[0];

            IList<Tag> tags = new List<Tag>();
            tags.Add(new Tag { Id = 0, NameEng = "--Select tag--" });
            if (tblTags.Rows.Count == 0) return null;

            foreach (DataRow row in tblTags.Rows)
            {
                var tag = new Tag();
                tag.Id = Convert.ToInt32(row[nameof(Tag.Id)]);
                tag.NameEng = row[nameof(Tag.NameEng)].ToString();
                tags.Add(tag);
            }

            return tags;
        }


        public IList<string> LoadAllTagTypes()
        {
            IList<String> tagTypes = new List<String>();

            var tblTagTypes = SqlHelper.ExecuteDataset(CS, nameof(LoadAllTagTypes)).Tables[0];
            if (tblTagTypes == null) return null;

            foreach (DataRow row in tblTagTypes.Rows)
            {
                tagTypes.Add(row[nameof(Tag.TagTypeNameEng)].ToString());
            }

            return tagTypes;
        }

       

        public IList<Tag> GetApartmentTags(int apartmentId)
        {
            IList<Tag> tags = new List<Tag>();

            var tblTags = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentTags), apartmentId).Tables[0];
            if (tblTags == null) return null;

            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(new Tag
                {
                    Id = (int)row[nameof(Tag.Id)],
                    Name = row[nameof(Tag.Name)].ToString(),
                    NameEng = row[nameof(Tag.NameEng)].ToString(),
                    TagTypeID = (int)row[nameof(Tag.TagTypeID)],
                    TagTypeNameEng = row[nameof(Tag.TagTypeNameEng)].ToString()
                });
            }
            return tags;
        }


        public void AddNewTag(int typeID, string nameEng)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddNewTag), nameEng, typeID);
        }


        public void DeleteTag(int tagId)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteTag), tagId);
        }


        public void DeleteApartmentTagByID(int tagID, int apartmentID)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartmentTagByID), tagID, apartmentID);
        }


        public void AddNewTagToApartment(int tagID, int apartmentID)
        {
            Guid guid = Guid.NewGuid();
            SqlHelper.ExecuteNonQuery(CS, nameof(AddNewTagToApartment), tagID, apartmentID, guid);
        }
                

        public IList<Tag> GetUnusedTagsOnApartment(int apartmentId)
        {
            IList<Tag> tags = new List<Tag>();

            var tblTags = SqlHelper.ExecuteDataset(CS, nameof(GetUnusedTagsOnApartment), apartmentId).Tables[0];
            if (tblTags == null) return null;

            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(new Tag
                {
                    Id = (int)row[nameof(Tag.Id)],
                    NameEng = row[nameof(Tag.NameEng)].ToString(),
                    TagTypeID = (int)row[nameof(Tag.TagTypeID)],
                    TagTypeNameEng = row[nameof(Tag.TagTypeNameEng)].ToString(),
                });
            }
            return tags;
        }
        /////////////////////////////////////////////


        //      USER

        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(GetAllUsers)).Tables[0];
            if (tblUsers == null) return null;

            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(new User
                {
                    Id = (int)row[nameof(User.Id)],
                    UserName = row[nameof(User.UserName)].ToString(),
                    Email = row[nameof(User.Email)].ToString(),
                    PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                    Address = row[nameof(User.Address)].ToString()
                });
            }

            return users;
        }


        public User GetUserByID(int apartmentId)
        {
            User user = new User();

            var tblUser = SqlHelper.ExecuteDataset(CS, nameof(GetUserByID), apartmentId).Tables[0];
            if (tblUser.Rows.Count == 0) return null;

            DataRow row = tblUser.Rows[0];

            user.Id = (int)row[nameof(User.Id)];
            user.UserName = row[nameof(User.UserName)].ToString();
            user.Details = row[nameof(User.Details)].ToString();

            return user;
        }


        public User GetUnregisteredUser(int apartmentId)
        {
            User user= new User();
            var tblUser = SqlHelper.ExecuteDataset(CS, nameof(GetUnregisteredUser), apartmentId).Tables[0];
            if (tblUser.Rows.Count == 0) return null;

            DataRow row = tblUser.Rows[0];
                        
            user.UserName = row[nameof(User.UserName)].ToString();
            user.Email = row[nameof(User.Email)].ToString();
            user.PhoneNumber = row[nameof(User.PhoneNumber)].ToString();
            user.Details = row[nameof(User.Details)].ToString();
            user.Address = row[nameof(User.Address)].ToString();

            return user;
        }


        public User AuthUser(string username, string password)
        {
            var tblAuth = SqlHelper.ExecuteDataset(CS, nameof(AuthUser), username, password).Tables[0];
            if (tblAuth.Rows.Count == 0) return null;

            DataRow row = tblAuth.Rows[0];

            return new User
            {
                Id = (int)row[nameof(User.Id)],
                UserName = row[nameof(User.UserName)].ToString(),
                Email = row[nameof(User.Email)].ToString(),
                PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                Address = row[nameof(User.Address)].ToString()
            };
        }

        public void CreateUser(User u)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateUser), u.Email, u.UserName, Cryptography.HashPassword(u.Password), u.Address, u.PhoneNumber);
        }


        ////////////////////////////////////

        //      Apartment reservation

        public void CreateApartmentReservationById(int registeredUserId, int apartmentId,string details)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateApartmentReservationById), registeredUserId, apartmentId, details);
        }
        
        public void CreateApartmentReservation(int apartmentId,string username, string email, string phonenumber, string address,string details)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateApartmentReservation),apartmentId, username, email, phonenumber, address, details);
        }

        public void DeleteApartmentReservation(int apartmentId)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartmentReservation), apartmentId);
        }

        public void UpdateApartmentReservation(int apartmentId, string details, string userName, string phoneNumber, string email, string address)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(UpdateApartmentReservation), apartmentId, details, userName, phoneNumber, email, address);
        }

        public void UpdateApartmentReservationByUserId(int apartmentId, string details, int registeredUserId)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(UpdateApartmentReservationByUserId), apartmentId, details, registeredUserId);
        }

        ///////////////////////////////////


        //      STATUSES


        public int GetApartmentStatus(int apartmentId)
        {            
            int statusId;
            var tblApartmentStatus = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentStatus), apartmentId).Tables[0];
            if (tblApartmentStatus.Rows.Count == 0) return 0;

            DataRow row = tblApartmentStatus.Rows[0];

            statusId = (int)row[nameof(Apartment.StatusId)];            

            return statusId;
        }


        public IList<Status> GetStatuses()
        {            
            IList<Status> statusList = new List<Status>();
            var tblStatuses = SqlHelper.ExecuteDataset(CS, nameof(GetStatuses)).Tables[0];

            if (tblStatuses.Rows.Count == 0) return null;

            statusList.Add(new Status { Id = 0, NameEng = "--Select status--" });

            foreach (DataRow row in tblStatuses.Rows)
            {
                statusList.Add(new Status
                {
                    Id = (int)row[nameof(Status.Id)],
                    Name = row[nameof(Status.Name)].ToString(),
                    NameEng = row[nameof(Status.NameEng)].ToString(),

                });
            }
            return statusList;
        }


        public string GetStatuses(int statusId)
        {
            if (statusId == 1) return "Occupied";

            else if (statusId == 2) return "Reserved";

            else return "Vacant";
        }
        ///////////////////////////////////////


        //      CITY

        public City GetCityByID(int id)
        {

            var tblCity = SqlHelper.ExecuteDataset(CS, nameof(GetCityByID), id).Tables[0];
            if (tblCity == null) return null;
            DataRow row = tblCity.Rows[0];

            return new City
            {
                Id = (int)row[nameof(City.Id)],
                Name = row[nameof(City.Name)].ToString()
            };
        }


        public IList<City> GetAllCities()
        {
            IList<City> cities = new List<City>();

            var tblCities = SqlHelper.ExecuteDataset(CS, nameof(GetAllCities)).Tables[0];
            if (tblCities.Rows.Count == 0) return null;

            cities.Add(new City { Id = 0, Name = "--Select city--" });

            foreach (DataRow row in tblCities.Rows)
            {
                cities.Add(new City
                {
                    Id = (int)row[nameof(City.Id)],
                    Name = row[nameof(City.Name)].ToString()
                });
            }

            return cities;
        }

        ///////////////////////////////////////


        //      APARTMENT OWNER

        public ApartmentOwner GetApartmentOwnerById(int ownerId)
        {
            ApartmentOwner apartmentOwner = new ApartmentOwner();

            var tblApartmentOwner = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentOwnerById), ownerId).Tables[0];
            if (tblApartmentOwner.Rows.Count == 0) return null;

            DataRow row = tblApartmentOwner.Rows[0];

            apartmentOwner.Id = (int)row[nameof(ApartmentOwner.Id)];
            apartmentOwner.Name = row[nameof(ApartmentOwner.Name)].ToString();

            return apartmentOwner;
        }


        public IList<ApartmentOwner> GetApartmentOwners()
        {
            IList<ApartmentOwner> apartmentOwners = new List<ApartmentOwner>();

            var tblApartmentOwners = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentOwners)).Tables[0];

            if (tblApartmentOwners.Rows.Count == 0) return null;

            foreach (DataRow row in tblApartmentOwners.Rows)
            {
                var owner = new ApartmentOwner();
                owner.Id = Convert.ToInt32(row[nameof(ApartmentOwner.Id)]);
                owner.Name = row[nameof(ApartmentOwner.Name)].ToString();
                apartmentOwners.Add(owner);
            }

            return apartmentOwners;
        }


        public ApartmentOwner GetApartmentOwnerByApartmentId(int ownerId)
        {
            ApartmentOwner apartmentOwner = new ApartmentOwner();

            var tblApartmentOwner = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentOwnerByApartmentId), ownerId).Tables[0];
            if (tblApartmentOwner.Rows.Count == 0) return null;

            DataRow row = tblApartmentOwner.Rows[0];

            apartmentOwner.Id = (int)row[nameof(ApartmentOwner.Id)];
            apartmentOwner.Name = row[nameof(ApartmentOwner.Name)].ToString();

            return apartmentOwner;
        }


        ///////////////////////////////////////


        //      APARTMENTS PICTURES

        public IList<ApartmentPicture> GetApartmentPictures()
        {
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();

            var tblApartmentsPictures = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentPictures)).Tables[0];
            if (tblApartmentsPictures == null) return null;

            foreach (DataRow row in tblApartmentsPictures.Rows)
            {
                ApartmentPicture picture = new ApartmentPicture();
                picture.Id = (int)row[nameof(ApartmentPicture.Id)];
                picture.ApartmentId = (int)row[nameof(ApartmentPicture.ApartmentId)];
                picture.Name = row[nameof(ApartmentPicture.Name)].ToString();
                picture.IsRepresentative = row[nameof(ApartmentPicture.IsRepresentative)].ToString() == "0" ? false : true;
                picture.Path = (string)row[nameof(ApartmentPicture.Path)];

                apartmentPictures.Add(picture);
            }

            return apartmentPictures;
        }


        public IList<ApartmentPicture> GetApartmentPicturesByID(int apartmentId)
        {
            IList<ApartmentPicture> apartmentPicturess = new List<ApartmentPicture>();

            var tblApartmentsPictures = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentPicturesByID), apartmentId).Tables[0];
            if (tblApartmentsPictures == null) return null;

            foreach (DataRow row in tblApartmentsPictures.Rows)
            {
                ApartmentPicture picture = new ApartmentPicture();
                picture.Id = (int)row[nameof(ApartmentPicture.Id)];
                picture.ApartmentId = (int)row[nameof(ApartmentPicture.ApartmentId)];
                picture.Name = row[nameof(ApartmentPicture.Name)].ToString();

                picture.IsRepresentative = row[nameof(ApartmentPicture.IsRepresentative)].ToString() == "0" ? false : true;


                picture.Path = (string)row[nameof(ApartmentPicture.Path)];

                apartmentPicturess.Add(picture);
            }

            return apartmentPicturess;
        }


        public void AddPictures(int apartmentId, string path)
        {
           SqlHelper.ExecuteNonQuery(CS, nameof(AddPictures), apartmentId, path);
        }


        public int GetNumberOfApartmentPictures(int apartmentId) 
        {           

            var tblNumberOfPictures = SqlHelper.ExecuteDataset(CS, nameof(GetNumberOfApartmentPictures), apartmentId).Tables[0];
            if (tblNumberOfPictures.Rows.Count == 0) return 0;

            DataRow row = tblNumberOfPictures.Rows[0];

            int broj = (int)row[nameof(Apartment.NumberOfPictures)];

            return broj;
        }

        public void SetRepresentativePicture(int apartmentId,int newRepresentative)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(SetRepresentativePicture), apartmentId, newRepresentative);
        }

        public void DeleteApartmentPictureByID(int imageId)
        {
            SqlHelper.ExecuteDataset(CS, nameof(DeleteApartmentPictureByID), imageId);
        }

        public string GetImagePath(int imageId)
        {
            var tblPath = SqlHelper.ExecuteDataset(CS, nameof(GetImagePath), imageId).Tables[0];
            if (tblPath.Rows.Count == 0) return null;

            DataRow row = tblPath.Rows[0];

            return row[nameof(ApartmentPicture.Path)].ToString();             
        }

        //  Reservation
        public void CreateNewPublicReservation(Reservation reservation)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateNewPublicReservation), reservation.ApartmentId, reservation.FirstName + " " + reservation.LastName, reservation.Email, reservation.Phone, reservation.DateFrom + " - " + reservation.DateTo + " odrasli: " + reservation.Adults + " djeca: " + reservation.Children);
        }

        //  Review
        public void CreateNewReview(Review review)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateNewReview), review.userId, review.stars, review.description, review.apartmentId);
        }
        public int GetReview(int apartmentId)
        {
            IList<int> numberOfReviews = new List<int>();

            var tblnumberOfStars = SqlHelper.ExecuteDataset(CS, nameof(GetReview), apartmentId).Tables[0];
            if (tblnumberOfStars.Rows.Count == 0) return 0;

            foreach (DataRow row in tblnumberOfStars.Rows)
            {
                numberOfReviews.Add((int)row["Stars"]);
            }

            int suma = 0;

            foreach (int stars in numberOfReviews)
            {
                suma += stars;
            }

            return suma / numberOfReviews.Count;
        }
    }
}

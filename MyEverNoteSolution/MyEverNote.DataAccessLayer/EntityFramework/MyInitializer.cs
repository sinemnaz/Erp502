using FakeData;
using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.DataAccessLayer.EntityFramework
{
    public class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            EverNoteUser admin = new EverNoteUser()
            {
                Name = "Sinem",
                Surname = "Özmen",
                Email = "sinem@gmail.com",
                ActiveGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                UserName = "sinemo",
                Password = "12345",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUserName="sinemo",
                ProfileImageFileName="userimg.jfif"
            };
            EverNoteUser standartuser = new EverNoteUser()
            {
                Name = "Aysunur",
                Surname = "Özmen",
                Email = "aysunur@gmail.com",
                ActiveGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                UserName = "aysunuro",
                Password = "54321",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUserName="sinemo",
                ProfileImageFileName = "userimg.jfif"
            };
            context.EverNoteUsers.Add(admin);
            context.EverNoteUsers.Add(standartuser);

            //Adding fake user
            for (int i = 0; i < 8; i++)
            {
                EverNoteUser fakeuser = new EverNoteUser()
                {
                Name = NameData.GetFirstName(),
                Surname = NameData.GetSurname(),
                Email = NetworkData.GetEmail(),
                ActiveGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                UserName = $"user{i}",
                Password = "123",
                CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-2),DateTime.Now),
                ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-2), DateTime.Now),
                ModifiedUserName = $"user{i}",
                ProfileImageFileName = "userimg.jfif"
                };
                context.EverNoteUsers.Add(fakeuser);
            }

            context.SaveChanges();

            //user lidt for using
            List<EverNoteUser> userlist = context.EverNoteUsers.ToList();

            //adding fake categories
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = PlaceData.GetStreetName(),
                    Description=PlaceData.GetAddress(),
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    ModifiedUserName="sinemo"
                };
                context.Categories.Add(cat);
                //adding fake notes
                for (int k = 0; k < NumberData.GetNumber(5,9); k++)
                {
                    EverNoteUser owner = userlist[NumberData.GetNumber(0, userlist.Count - 1)];
                    Note note = new Note()
                    {
                        Title = TextData.GetAlphabetical(NumberData.GetNumber(5, 25)),
                        Text=TextData.GetSentences(NumberData.GetNumber(1,3)),
                        Category=cat,
                        IsDraft=false,
                        LikeCount=NumberData.GetNumber(1,9),
                        Owner=owner,
                        CreatedOn=DateTimeData.GetDatetime(DateTime.Now.AddYears(-2),DateTime.Now),
                        ModifiedOn=DateTimeData.GetDatetime(DateTime.Now.AddYears(-2),DateTime.Now),
                        ModifiedUserName=owner.UserName
                    };
                    cat.Notes.Add(note);
                    //adding fake comment
                    for (int j = 0; j < NumberData.GetNumber(3,5); j++)
                    {
                        EverNoteUser comment_owner = userlist[NumberData.GetNumber(0, userlist.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = TextData.GetSentence(),
                            Owner   =comment_owner,
                            CreatedOn=DateTimeData.GetDatetime(DateTime.Now.AddYears(-2),DateTime.Now),
                            ModifiedOn=DateTimeData.GetDatetime(DateTime.Now.AddYears(-2),DateTime.Now),
                            ModifiedUserName=comment_owner.UserName
                            //Note=note
                        };
                        note.Comments.Add(comment);

                        //adding fake likes
                        for (int m = 0; m < note.LikeCount; m++)
                        {
                            Liked liked = new Liked()
                            {
                                LikedUser = userlist[m]
                            };
                            note.Likes.Add(liked);
                        }
                    }
                }
                context.SaveChanges();
            }
            
        }
    }
}

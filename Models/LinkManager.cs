using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace linkManagerApp.Models {

    // the DbContext come from Microsoft.EntityFrameworkCore
    public class LinkManager : DbContext {

        // it represent the database table
        private DbSet<Category> tblCategory{get;set;}
        private DbSet<Link> tblLinks{get;set;}

        public Link link {get;set;}
        public Category category {get;set;}
        public WebLogin login {get;set;}

        // -------------------------------------------------- get/sets
        public List<Link> links {
            get {
                // covert the DbSet to a list so we can use it 
                // the method comes from the Linq
                return tblLinks.OrderBy(c => c.linkName).ToList();
            }
        }

        public List<Category> categories {
            get {
                // covert the DbSet to a list so we can use it 
                // the method comes from the Linq
                return tblCategory.ToList();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8,0,11)));
        }

        //------------------------------------------------- public methods
        public SelectList getCategoryList(){
            // using Linq methods to query data and return as List
            // OrderBy(c => c.lastName) means sort the list by lastName
            List<Category> listData = tblCategory.ToList();

            //other methods...
            //tblCustomer.Where();

            // the second parameter is the value, the third parameter is the label
            return new SelectList(listData, "categoryID", "categoryName");
        }

        public Category getCategory(string categoryID){

            category = tblCategory.Find(Convert.ToInt32(categoryID));

            return category;
        }

        public Link getLink(string linkID){

            link = tblLinks.Find(Convert.ToInt32(linkID));

            return link;
        }

        public Link SyncCategoryID(string categoryID){
            link = new Link();
            link.categoryRefID = Convert.ToInt32(categoryID);
            //Console.WriteLine(link.categoryRefID);
            return link;
        }

        // public Link changeCustomer(int linkId){

        //     link = tblCustomer.Find(linkId);
        //     // the second parameter is the value, the third parameter is the label
        //     return link;
        // }
    }

}
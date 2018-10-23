using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {
               
                //code to go here

                return null;
            }
        }//eom

        //this method is an OLTP conplex method
        //this method may alter multiple tracks
        //the method
        public void Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            //the using sets up the transaction environment
            //if the logic does not reach a .SaveChanges() method
            //all work is rolled back.

            //a list of string to be used to handle any number of errors
            //generated while doing the transaction
            //all errors can then be returned to the MessageUserControl
            List<String> resons = null;
            using (var context = new ChinookContext())
            {
                //code to go here
                //Part One
                //determine if a new playlist is needed
                //determine the tracknumber dependent of if a playlist already exists.
                Playlist exists = context.Playlists.Where(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) 
                                                            && x.Name.Equals(playlistname, StringComparison.OrdinalIgnoreCase))
                                                   .Select(x => x).FirstOrDefault();
                //create an instance for PlaylistTrack
                PlaylistTrack newTrack = null;
                //initialize a local tracknumber
                int tracknumber = 0;

                if (exists == null)
                {
                    //this is a new playlist being created
                    exists = new Playlist();
                    exists.Name = playlistname;
                    exists.UserName = username;
                    exists = context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    //this is an existing playlist
                    //calculate the new proposed tracknumber
                    tracknumber = exists.PlaylistTracks.Count() + 1;
                    //business rule: track may only exists once on a playlist
                    //it may exists on many different playlist
                    //.SingleOrDefault expects a single instance to be returned
                    newTrack = exists.PlaylistTracks.SingleOrDefault(
                        x => x.TrackId == trackid);
                    if(newTrack != null)
                    {
                        resons.Add("Track already exists on the playlist.");
                    }
                }
                if (resons.Count() > 0)
                {
                    //issue the BusinessRuleExpection(title, list of error strings)
                    throw new BusinessRuleException("Adding track to playlist", resons);
                }
                else
                {
                    //Part Two : Add the track
                    newTrack = new PlaylistTrack();
                    newTrack.TrackId = trackid;
                    newTrack.TrackNumber = tracknumber;
                    //what about the playlistid?
                    //Note: the Pkey for playlistId may not yet exists
                    //using navigatiion one can let HashSet handle the expected
                    //playlist Pkey vlaue
                    exists.PlaylistTracks.Add(newTrack);
                    //at this point all records are in staged state
                    //physicall add all data for the transaction to 
                    //the database and commit
                    context.SaveChanges();
                }
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                //code to go here 

            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
               //code to go here


            }
        }//eom
    }
}

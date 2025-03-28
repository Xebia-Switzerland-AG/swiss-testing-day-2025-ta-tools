const {
  sequelize,
  Song,
  User,
  Bookmark,
  History
} = require('../src/models')

const Promise = require('bluebird')
const songs = require('./songs.json')
const users = require('./users.json')
const bookmarks = require('./bookmarks.json')
const histories = require('./histories.json')

function resetDb () {
  sequelize.sync({ force: true })
    .then(async function () {
      console.log('✅ Datenbank synchronisiert (force: true)')

      // Users
      await Promise.all(
        users.map(user =>
          User.create(user)
            .then(() => {
              console.log(`✅ User '${user.email}' wurde erstellt`)
            })
            .catch(err => {
              console.error(`❌ Fehler beim Erstellen von User '${user.email}':`, err.message)
            })
        )
      )

      // Songs
      await Promise.all(
        songs.map(song =>
          Song.create(song)
            .then(() => {
              console.log(`✅ Song '${song.title}' wurde erstellt`)
            })
            .catch(err => {
              console.error(`❌ Fehler beim Erstellen von Song '${song.title}':`, err.message)
            })
        )
      )

      // Bookmarks
      await Promise.all(
        bookmarks.map(bookmark =>
          Bookmark.create(bookmark)
            .then(() => {
              console.log(`✅ Bookmark wurde erstellt`)
            })
            .catch(err => {
              console.error('❌ Fehler beim Erstellen eines Bookmarks:', err.message)
            })
        )
      )

      // Histories
      await Promise.all(
        histories.map(history =>
          History.create(history)
            .then(() => {
              console.log(`✅ History-Eintrag wurde erstellt`)
            })
            .catch(err => {
              console.error('❌ Fehler beim Erstellen eines History-Eintrags:', err.message)
            })
        )
      )

      console.log('🎉 Datenbank-Reset abgeschlossen!')
    })
    .catch((err) => {
      console.error('❌ Fehler beim Reset der Datenbank:', err)
    })
}

module.exports.resetDb = resetDb

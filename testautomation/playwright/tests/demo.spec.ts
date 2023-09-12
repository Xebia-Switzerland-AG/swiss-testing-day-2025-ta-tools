import { test, expect } from '@playwright/test';

const songMetadata = {
  "title": "Schatteboxe",
  "artist": "Zürich West",
  "genre": "Mundart",
  "album": "Love",
  "albumImageUrl": "https://zueriwest.ch/wp-content/uploads/2017/02/Disko_Love.png",
  "youtubeId": "TNW1sCFdDhI",
  "tab": "test",
  "lyrics": "D Sunne schynt dür d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nEh chasch es mitnäh wes der gfallt\nDe chasch es ha\nDu muesch mer nüt erkläre wed wosch ga\nEh d Stadt isch violett u d Schätte läng\nI weiss nume nid was söll i jetz mit däm?\nWed nomau muesch überlege, überleisch\nAber mir muesch nüt erkläre we de geisch\nI probieres z akzeptiere so wies isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du für eini bisch aber chasch sicher si\nDass i das gärn wett wüsse\nD Sunne schynt dür d Storen yy uf ds Pult\nU malt es chlyses Vieregg druf us Gold\nEh d Stadt isch violett u d Schätte läng\nI weiss nume nid was söll i jetz mit däm?\nI schatteboxe gäge d Wänd\n\nI probieres z akzeptiere wes so isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du für eini bisch aber chasch sicher si\nDass i das gärn wett wüsse\nD Sunne schynt dür d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nD Stadt isch violett u d Schätte läng\nI weiss nume nid was söll i jetz mit däm?\nI schatteboxe gäge d Wänd\nSchatteboxe gäge d Wänd"
}

test('should create song', async ({ page }) => {
  await page.goto('http://localhost:8080/#/songs/create');

  await page.getByTestId('newSongTitle').type(songMetadata.title)
  await page.getByTestId('newSongArtist').type(songMetadata.artist)
  await page.getByTestId('newSongGenre').type(songMetadata.genre)
  await page.getByTestId('newSongAlbum').type(songMetadata.album)
  await page.getByTestId('newSongAlbumImageUrl').type(songMetadata.albumImageUrl)
  await page.getByTestId('newSongYouTubeId').type(songMetadata.youtubeId)
  await page.getByTestId('newSongStructure').type(songMetadata.tab)
  await page.getByTestId('newSongLyrics').type(songMetadata.lyrics)

  await page.getByTestId('createSong').click()




});

test('get started link', async ({ page }) => {
  
});

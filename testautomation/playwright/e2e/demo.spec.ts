import { test, expect } from "@playwright/test";

const songMetadata = {
  title: "Schatteboxe",
  artist: "Zuerich West",
  genre: "Mundart",
  album: "Love",
  albumImageUrl:
    "https://images.genius.com/7d110c7aeea743ff17d07830d3247c65.1000x1000x1.jpg",
  youtubeId: "TNW1sCFdDhI",
  tab: "test",
  lyrics:
    "D Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nEh chasch es mitnaeh wes der gfallt\nDe chasch es ha\nDu muesch mer nuet erklaere wed wosch ga\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nWed nomau muesch ueberlege, ueberleisch\nAber mir muesch nuet erklaere we de geisch\nI probieres z akzeptiere so wies isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen yy uf ds Pult\nU malt es chlyses Vieregg druf us Gold\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\n\nI probieres z akzeptiere wes so isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nD Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\nSchatteboxe gaege d Waend",
};

test.beforeAll(async ({ request }) => {
  await request.get("http://localhost:8081/reset");
});
test.afterAll(async ({ request }) => {
  await request.get("http://localhost:8081/reset");
});

test("should create song", async ({ page }) => {
  await page.goto("http://localhost:8080");
  await page.getByTestId("createSongLink").click();

  await page.getByTestId("newSongTitle").type(songMetadata.title);
  await page.getByTestId("newSongArtist").type(songMetadata.artist);
  await page.getByTestId("newSongGenre").type(songMetadata.genre);
  await page.getByTestId("newSongAlbum").type(songMetadata.album);
  await page
    .getByTestId("newSongAlbumImageUrl")
    .type(songMetadata.albumImageUrl);
  await page.getByTestId("newSongYouTubeId").type(songMetadata.youtubeId);
  await page.getByTestId("newSongStructure").type(songMetadata.tab);
  await page
    .getByTestId("newSongLyrics")
    .type(songMetadata.lyrics, { timeout: 20_000 });

  const responsePromise = page.waitForResponse("**/songs");
  await page.getByTestId("createSong").click();
  const response = await responsePromise;

  expect(response.status()).toBe(200);

  const createdSong = await response.json();
  expect(createdSong.title).toBe(songMetadata.title);
  expect(createdSong.artist).toBe(songMetadata.artist);
  expect(createdSong.genre).toBe(songMetadata.genre);
  expect(createdSong.album).toBe(songMetadata.album);
  expect(createdSong.albumImageUrl).toBe(songMetadata.albumImageUrl);
  expect(createdSong.youtubeId).toBe(songMetadata.youtubeId);
  expect(createdSong.tab).toBe(songMetadata.tab);
  expect(createdSong.lyrics).toBe(songMetadata.lyrics);
});

test("should find song", async ({ page }) => {
  await page.goto("http://localhost:8080/");
  await page.getByTestId("search-bar").type("She's Kerosene");

  await expect(page.getByTestId("songTitle")).toHaveCount(1);

  await expect(page.getByTestId("songTitle")).toContainText("She's Kerosene");
  await expect(page.getByTestId("songArtist")).toContainText(
    "The Interrupters"
  );
  await expect(page.getByTestId("songGenre")).toContainText("Ska Punk");
});

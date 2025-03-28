describe("demo", () => {
  before(() => {
    cy.request("http://localhost:8081/reset");
  });  
  after(() => {
    cy.request("http://localhost:8081/reset");
  });

  it("should create song", () => {
    const songMetadata = {
      title: "Schatteboxe",
      artist: "Zuerich West",
      genre: "Mundart",
      album: "Love",
      albumImageUrl:
        "https://zueriwest.ch/wp-content/uploads/2017/02/Disko_Love.png",
      youtubeId: "TNW1sCFdDhI",
      tab: "test",
      lyrics:
        "D Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nEh chasch es mitnaeh wes der gfallt\nDe chasch es ha\nDu muesch mer nuet erklaere wed wosch ga\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nWed nomau muesch ueberlege, ueberleisch\nAber mir muesch nuet erklaere we de geisch\nI probieres z akzeptiere so wies isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen yy uf ds Pult\nU malt es chlyses Vieregg druf us Gold\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\n\nI probieres z akzeptiere wes so isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nD Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\nSchatteboxe gaege d Waend",
    };

    cy.visit("http://localhost:8080/");

    cy.get('[data-test-id="createSongLink"]').click();

    cy.get('[data-test-id="newSongTitle"]').type(songMetadata.title);
    cy.get('[data-test-id="newSongArtist"]').type(songMetadata.artist);
    cy.get('[data-test-id="newSongGenre"]').type(songMetadata.genre);
    cy.get('[data-test-id="newSongAlbum"]').type(songMetadata.album);
    cy.get('[data-test-id="newSongAlbumImageUrl"]').type(
      songMetadata.albumImageUrl
    );
    cy.get('[data-test-id="newSongYouTubeId"]').type(songMetadata.youtubeId);
    cy.get('[data-test-id="newSongStructure"]').type(songMetadata.tab);
    cy.get('[data-test-id="newSongLyrics"]').type(songMetadata.lyrics, {
      delay: 0,
    });

    cy.intercept("**/song", (request) => {
      request.continue((response) => {
        expect(response.body.title).to.be(songMetadata.title);
        expect(response.body.artist).to.be(songMetadata.artist);
        expect(response.body.genre).to.be(songMetadata.genre);
        expect(response.body.album).to.be(songMetadata.album);
        expect(response.body.albumImageUrl).to.be(songMetadata.albumImageUrl);
        expect(response.body.youtubeId).to.be(songMetadata.youtubeId);
        expect(response.body.tab).to.be(songMetadata.tab);
        expect(response.body.lyrics).to.be(songMetadata.lyrics);
      });
      cy.get('[data-test-id="createSong"]').click();
    });
  });

  it("should find song", () => {
    cy.visit("http://localhost:8080/");
    cy.get('[data-test-id="search-bar"]').type("She's Kerosene");
    cy.get('[data-test-id="songTitle"]').should("have.length", 1);

    cy.get('[data-test-id="songTitle"]').should("contain.text", "She's Kerosene");
    cy.get('[data-test-id="songArtist"]').should("contain.text", "The Interrupters");
    cy.get('[data-test-id="songGenre"]').should("contain.text", "Ska Punk");
  });
});

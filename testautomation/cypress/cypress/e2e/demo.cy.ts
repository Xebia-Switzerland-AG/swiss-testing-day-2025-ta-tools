describe("demo", () => {
  after(() => {
    cy.request("http://localhost:8081/reset");
  });

  it("should create song", () => {
    cy.visit("http://localhost:8080/#/songs/create");

    cy.fixture("testSong").then((songMetadata) => {
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
    });

    cy.get('[data-test-id="createSong"]').click();
    cy.wait(1000);
  });

  it("should find song", () => {
    cy.visit("http://localhost:8080/");
    cy.fixture("testSong").then((songMetadata) => {
      cy.get('[data-test-id="search-bar"]').type(songMetadata.title);
      cy.wait(100);
      cy.get('[data-test-id="songTitle"]').should(
        "contain.text",
        songMetadata.title
      );
      cy.get('[data-test-id="songArtist"]').should(
        "contain.text",
        songMetadata.artist
      );
      cy.get('[data-test-id="songGenre"]').should(
        "contain.text",
        songMetadata.genre
      );
    });
  });
});

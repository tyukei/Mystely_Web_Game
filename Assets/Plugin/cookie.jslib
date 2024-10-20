mergeInto(LibraryManager.library, {
   
    SetCurrentState: function(state) {
      document.cookie = 'current_state=' + state;
    },
    GetCurrentState: function() {
      return parseInt(document.cookie.split('=')[1]);
    }
   
  });
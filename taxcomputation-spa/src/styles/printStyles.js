/* eslint-disable no-useless-escape */
export default `<style type="text/css">/* poppins-devanagari-400-italic*/
@font-face {
  font-family: 'Poppins';
  font-style: italic;
  font-display: swap;
  font-weight: 400;
  src: url(/static/media/poppins-devanagari-400-italic.0501075a.woff2) format('woff2'), url(/static/media/poppins-all-400-italic.3377ac1b.woff) format('woff');
  unicode-range: U+0900-097F, U+1CD0-1CF6, U+1CF8-1CF9, U+200C-200D, U+20A8, U+20B9, U+25CC, U+A830-A839, U+A8E0-A8FB;
}
/* poppins-latin-ext-400-italic*/
@font-face {
  font-family: 'Poppins';
  font-style: italic;
  font-display: swap;
  font-weight: 400;
  src: url(/static/media/poppins-latin-ext-400-italic.aaefa4cf.woff2) format('woff2'), url(/static/media/poppins-all-400-italic.3377ac1b.woff) format('woff');
  unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
}
/* poppins-latin-400-italic*/
@font-face {
  font-family: 'Poppins';
  font-style: italic;
  font-display: swap;
  font-weight: 400;
  src: url(/static/media/poppins-latin-400-italic.c8844b25.woff2) format('woff2'), url(/static/media/poppins-all-400-italic.3377ac1b.woff) format('woff');
  unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
}
/* poppins-devanagari-400-normal*/
@font-face {
  font-family: 'Poppins';
  font-style: normal;
  font-display: swap;
  font-weight: 400;
  src: url(/static/media/poppins-devanagari-400-normal.d5e78c53.woff2) format('woff2'), url(/static/media/poppins-all-400-normal.2b7b1aec.woff) format('woff');
  unicode-range: U+0900-097F, U+1CD0-1CF6, U+1CF8-1CF9, U+200C-200D, U+20A8, U+20B9, U+25CC, U+A830-A839, U+A8E0-A8FB;
}
/* poppins-latin-ext-400-normal*/
@font-face {
  font-family: 'Poppins';
  font-style: normal;
  font-display: swap;
  font-weight: 400;
  src: url(/static/media/poppins-latin-ext-400-normal.4d1490f3.woff2) format('woff2'), url(/static/media/poppins-all-400-normal.2b7b1aec.woff) format('woff');
  unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
}
/* poppins-latin-400-normal*/
@font-face {
  font-family: 'Poppins';
  font-style: normal;
  font-display: swap;
  font-weight: 400;
  src: url(/static/media/poppins-latin-400-normal.9ed361bb.woff2) format('woff2'), url(/static/media/poppins-all-400-normal.2b7b1aec.woff) format('woff');
  unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
}
</style>
<style type="text/css">body {
  margin: 0;
  font-family: "Poppins";
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  background-color: #f5f6f8;
}

/* The emerging W3C standard
   that is currently Firefox-only */
* {
  scrollbar-width: thin;
  scrollbar-color: rgb(180, 180, 180) #f5f6f8;
}

/* Works on Chrome/Edge/Safari */
*::-webkit-scrollbar {
  width: 12px;
  height: 12px;
}
*::-webkit-scrollbar-track {
  background: #f5f6f8;
}
*::-webkit-scrollbar-thumb {
  background-color: rgb(180, 180, 180);
  border-radius: 20px;
  border: 3px solid #f5f6f8;
}

.accent-color {
  color: #2196f3;
}

.divider {
  width: 100%;
  height: 2px;
  background: #f5f6f8;
}

.view-description {
  font-weight: 600;
  margin: 0px 0px 10px 0px;
}

.auth-link {
  text-decoration: none;
  color: inherit;
  text-align: center;
  transition: color 0.5s;
}

.back-to-app-link {
  margin-bottom: 0;
  margin-top: 20;
  font-size: 14;
  text-align: center;
  transition: color 0.5s;
  cursor: pointer;
}

.auth-link:hover,
.back-to-app-link:hover {
  color: #2196f3;
}

.sidebar-link {
  text-decoration: none;
  color: inherit;
  transition: margin-left 0.3s ease-in-out;
}

.sidebar-link:hover {
  margin-left: 3px;
}

.pi-20 {
  font-size: 20px !important;
}

.pi-24 {
  font-size: 24px !important;
}

.drop-shadow {
  box-shadow: 0 2px 1px -1px rgba(0, 0, 0, 0.2), 0 1px 1px 0 rgba(0, 0, 0, 0.14),
    0 1px 3px 0 rgba(0, 0, 0, 0.12);
}

.settings-item {
  cursor: pointer;
  padding: 5px;
  margin: 0px;
  text-align: right;
  transition: background-color 0.3s;
}

.settings-item:hover {
  background-color: #eee;
}

.overlay {
  background-color: rgba(0, 0, 0, 0.4);
  pointer-events: auto;
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  z-index: 1000;
}

.edit:hover {
  color: #ff8c00;
}

.delete:hover {
  color: #f00;
}

.error-boundary {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100vw;
  height: 100vh;
}
</style>
<style type="text/css">@charset "UTF-8";
:root {
  --surface-a:#ffffff;
  --surface-b:#f8f9fa;
  --surface-c:#e9ecef;
  --surface-d:#dee2e6;
  --surface-e:#ffffff;
  --surface-f:#ffffff;
  --text-color:#495057;
  --text-color-secondary:#6c757d;
  --primary-color:#2196F3;
  --primary-color-text:#ffffff;
  --font-family:-apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica, Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol; }

* {
  -webkit-box-sizing: border-box;
          box-sizing: border-box; }

.p-component {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
  font-size: 1rem;
  font-weight: normal; }

.p-component-overlay {
  background-color: rgba(0, 0, 0, 0.4);
  -webkit-transition-duration: 0.2s;
          transition-duration: 0.2s; }

.p-disabled, .p-component:disabled {
  opacity: 0.6; }

.p-error, .p-invalid {
  color: #f44336; }

.p-text-secondary {
  color: #6c757d; }

.pi {
  font-size: 1rem; }

.p-link {
  font-size: 1rem;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
  border-radius: 3px; }
  .p-link:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }

.p-autocomplete .p-autocomplete-loader {
  right: 0.5rem; }
.p-autocomplete.p-autocomplete-dd .p-autocomplete-loader {
  right: 2.857rem; }
.p-autocomplete.p-autocomplete-multiple .p-autocomplete-multiple-container {
  padding: 0.25rem 0.5rem; }
  .p-autocomplete.p-autocomplete-multiple .p-autocomplete-multiple-container:not(.p-disabled):hover {
    border-color: #2196F3; }
  .p-autocomplete.p-autocomplete-multiple .p-autocomplete-multiple-container:not(.p-disabled).p-focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa;
    border-color: #2196F3; }
  .p-autocomplete.p-autocomplete-multiple .p-autocomplete-multiple-container .p-autocomplete-input-token {
    padding: 0.25rem 0; }
    .p-autocomplete.p-autocomplete-multiple .p-autocomplete-multiple-container .p-autocomplete-input-token input {
      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
      font-size: 1rem;
      color: #495057;
      padding: 0;
      margin: 0; }
  .p-autocomplete.p-autocomplete-multiple .p-autocomplete-multiple-container .p-autocomplete-token {
    padding: 0.25rem 0.5rem;
    margin-right: 0.5rem;
    background: #E3F2FD;
    color: #495057;
    border-radius: 3px; }
    .p-autocomplete.p-autocomplete-multiple .p-autocomplete-multiple-container .p-autocomplete-token .p-autocomplete-token-icon {
      margin-left: 0.5rem; }
.p-autocomplete.p-error > .p-inputtext, .p-autocomplete.p-invalid > .p-inputtext {
  border-color: #f44336; }

.p-autocomplete-panel {
  background: #ffffff;
  color: #495057;
  border: 0 none;
  border-radius: 3px;
  -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-autocomplete-panel .p-autocomplete-items {
    padding: 0.5rem 0; }
    .p-autocomplete-panel .p-autocomplete-items .p-autocomplete-item {
      margin: 0;
      padding: 0.5rem 1rem;
      border: 0 none;
      color: #495057;
      background: transparent;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      border-radius: 0; }
      .p-autocomplete-panel .p-autocomplete-items .p-autocomplete-item:hover {
        color: #495057;
        background: #e9ecef; }
      .p-autocomplete-panel .p-autocomplete-items .p-autocomplete-item.p-highlight {
        color: #495057;
        background: #E3F2FD; }

.p-calendar.p-error > .p-inputtext, .p-calendar.p-invalid > .p-inputtext {
  border-color: #f44336; }

.p-datepicker {
  padding: 0.5rem;
  background: #ffffff;
  color: #495057;
  border: 1px solid #ced4da;
  border-radius: 3px; }
  .p-datepicker:not(.p-datepicker-inline) {
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
    .p-datepicker:not(.p-datepicker-inline) .p-datepicker-header {
      background: #ffffff; }
  .p-datepicker .p-datepicker-header {
    padding: 0.5rem;
    color: #495057;
    background: #ffffff;
    font-weight: 600;
    margin: 0;
    border-bottom: 1px solid #dee2e6;
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
    .p-datepicker .p-datepicker-header .p-datepicker-prev,
    .p-datepicker .p-datepicker-header .p-datepicker-next {
      width: 2rem;
      height: 2rem;
      color: #6c757d;
      border: 0 none;
      background: transparent;
      border-radius: 50%;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
      .p-datepicker .p-datepicker-header .p-datepicker-prev:enabled:hover,
      .p-datepicker .p-datepicker-header .p-datepicker-next:enabled:hover {
        color: #495057;
        border-color: transparent;
        background: #e9ecef; }
      .p-datepicker .p-datepicker-header .p-datepicker-prev:focus,
      .p-datepicker .p-datepicker-header .p-datepicker-next:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-datepicker .p-datepicker-header .p-datepicker-title {
      line-height: 2rem; }
      .p-datepicker .p-datepicker-header .p-datepicker-title select {
        -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
        transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
        transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
        transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
        .p-datepicker .p-datepicker-header .p-datepicker-title select:focus {
          outline: 0 none;
          outline-offset: 0;
          -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                  box-shadow: 0 0 0 0.2rem #a6d5fa;
          border-color: #2196F3; }
      .p-datepicker .p-datepicker-header .p-datepicker-title .p-datepicker-month {
        margin-right: 0.5rem; }
  .p-datepicker table {
    font-size: 1rem;
    margin: 0.5rem 0; }
    .p-datepicker table th {
      padding: 0.5rem; }
      .p-datepicker table th > span {
        width: 2.5rem;
        height: 2.5rem; }
    .p-datepicker table td {
      padding: 0.5rem; }
      .p-datepicker table td > span {
        width: 2.5rem;
        height: 2.5rem;
        border-radius: 50%;
        -webkit-transition: -webkit-box-shadow 0.2s;
        transition: -webkit-box-shadow 0.2s;
        transition: box-shadow 0.2s;
        transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
        border: 1px solid transparent; }
        .p-datepicker table td > span.p-highlight {
          color: #495057;
          background: #E3F2FD; }
        .p-datepicker table td > span:focus {
          outline: 0 none;
          outline-offset: 0;
          -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                  box-shadow: 0 0 0 0.2rem #a6d5fa; }
      .p-datepicker table td.p-datepicker-today > span {
        background: #ced4da;
        color: #495057;
        border-color: transparent; }
        .p-datepicker table td.p-datepicker-today > span.p-highlight {
          color: #495057;
          background: #E3F2FD; }
  .p-datepicker .p-datepicker-buttonbar {
    padding: 1rem 0;
    border-top: 1px solid #dee2e6; }
    .p-datepicker .p-datepicker-buttonbar .p-button {
      width: auto; }
  .p-datepicker .p-timepicker {
    border-top: 1px solid #dee2e6;
    padding: 0.5rem; }
    .p-datepicker .p-timepicker button {
      width: 2rem;
      height: 2rem;
      color: #6c757d;
      border: 0 none;
      background: transparent;
      border-radius: 50%;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
      .p-datepicker .p-timepicker button:enabled:hover {
        color: #495057;
        border-color: transparent;
        background: #e9ecef; }
      .p-datepicker .p-timepicker button:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
      .p-datepicker .p-timepicker button:last-child {
        margin-top: .2em; }
    .p-datepicker .p-timepicker span {
      font-size: 1.25rem; }
    .p-datepicker .p-timepicker > div {
      padding: 0 0.5rem; }
  .p-datepicker.p-datepicker-timeonly .p-timepicker {
    border-top: 0 none; }
  .p-datepicker .p-monthpicker {
    margin: 0.5rem 0; }
    .p-datepicker .p-monthpicker .p-monthpicker-month {
      padding: 0.5rem;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      border-radius: 3px; }
      .p-datepicker .p-monthpicker .p-monthpicker-month.p-highlight {
        color: #495057;
        background: #E3F2FD; }
  .p-datepicker.p-datepicker-multiple-month .p-datepicker-group {
    border-right: 1px solid #dee2e6;
    padding-right: 0.5rem;
    padding-left: 0.5rem;
    padding-top: 0;
    padding-bottom: 0; }
    .p-datepicker.p-datepicker-multiple-month .p-datepicker-group:first-child {
      padding-left: 0; }
    .p-datepicker.p-datepicker-multiple-month .p-datepicker-group:last-child {
      padding-right: 0;
      border-right: 0 none; }
  .p-datepicker:not(.p-disabled) table td span:not(.p-highlight):not(.p-disabled):hover {
    background: #e9ecef; }
  .p-datepicker:not(.p-disabled) table td span:not(.p-highlight):not(.p-disabled):focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .p-datepicker:not(.p-disabled) .p-monthpicker .p-monthpicker-month:not(.p-highlight):not(.p-disabled):hover {
    background: #e9ecef; }
  .p-datepicker:not(.p-disabled) .p-monthpicker .p-monthpicker-month:not(.p-highlight):not(.p-disabled):focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }

.p-datepicker-mask.p-component-overlay {
  background: rgba(0, 0, 0, 0.4); }

@media screen and (max-width: 769px) {
  .p-datepicker table th, .p-datepicker table td {
    padding: 0; } }
.p-checkbox {
  width: 20px;
  height: 20px; }
  .p-checkbox .p-checkbox-box {
    border: 2px solid #ced4da;
    background: #ffffff;
    width: 20px;
    height: 20px;
    color: #495057;
    border-radius: 3px;
    -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-checkbox .p-checkbox-box .p-checkbox-icon {
      -webkit-transition-duration: 0.2s;
              transition-duration: 0.2s;
      color: #ffffff;
      font-size: 14px; }
    .p-checkbox .p-checkbox-box:not(.p-disabled):hover {
      border-color: #2196F3; }
    .p-checkbox .p-checkbox-box:not(.p-disabled).p-focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa;
      border-color: #2196F3; }
    .p-checkbox .p-checkbox-box.p-highlight {
      border-color: #2196F3;
      background: #2196F3; }
      .p-checkbox .p-checkbox-box.p-highlight:not(.p-disabled):hover {
        border-color: #0b7ad1;
        background: #0b7ad1;
        color: #ffffff; }
  .p-checkbox.p-error > .p-checkbox-box, .p-checkbox.p-invalid > .p-checkbox-box {
    border-color: #f44336; }

.p-input-filled .p-checkbox .p-checkbox-box {
  background-color: #f8f9fa; }
  .p-input-filled .p-checkbox .p-checkbox-box:not(.p-disabled):hover {
    background-color: #f8f9fa; }
  .p-input-filled .p-checkbox .p-checkbox-box.p-highlight {
    background: #2196F3; }
    .p-input-filled .p-checkbox .p-checkbox-box.p-highlight:not(.p-disabled):hover {
      background: #0b7ad1; }

.p-chips .p-chips-multiple-container {
  padding: 0.25rem 0.5rem; }
  .p-chips .p-chips-multiple-container:not(.p-disabled):hover {
    border-color: #2196F3; }
  .p-chips .p-chips-multiple-container:not(.p-disabled).p-focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa;
    border-color: #2196F3; }
  .p-chips .p-chips-multiple-container .p-chips-token {
    padding: 0.25rem 0.5rem;
    margin-right: 0.5rem;
    background: #E3F2FD;
    color: #495057;
    border-radius: 3px; }
    .p-chips .p-chips-multiple-container .p-chips-token .p-chips-token-icon {
      margin-left: 0.5rem; }
  .p-chips .p-chips-multiple-container .p-chips-input-token {
    padding: 0.25rem 0; }
    .p-chips .p-chips-multiple-container .p-chips-input-token input {
      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
      font-size: 1rem;
      color: #495057;
      padding: 0;
      margin: 0; }
.p-chips.p-error > .p-inputtext, .p-chips.p-invalid > .p-inputtext {
  border-color: #f44336; }

.p-colorpicker-preview {
  width: 2rem;
  height: 2rem; }

.p-colorpicker-panel {
  background: #323232;
  border-color: #191919; }
  .p-colorpicker-panel .p-colorpicker-color-handle,
  .p-colorpicker-panel .p-colorpicker-hue-handle {
    border-color: #ffffff; }

.p-colorpicker-overlay-panel {
  -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }

.p-dropdown {
  background: #ffffff;
  border: 1px solid #ced4da;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  border-radius: 3px; }
  .p-dropdown:not(.p-disabled):hover {
    border-color: #2196F3; }
  .p-dropdown:not(.p-disabled).p-focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa;
    border-color: #2196F3; }
  .p-dropdown.p-dropdown-clearable .p-dropdown-label {
    padding-right: 1.5rem; }
  .p-dropdown .p-dropdown-label {
    background: transparent;
    border: 0 none; }
    .p-dropdown .p-dropdown-label.p-placeholder {
      color: #6c757d; }
    .p-dropdown .p-dropdown-label:enabled:focus {
      outline: 0 none;
      -webkit-box-shadow: none;
              box-shadow: none; }
  .p-dropdown .p-dropdown-trigger {
    background: transparent;
    color: #6c757d;
    width: 2.357rem;
    border-top-right-radius: 3px;
    border-bottom-right-radius: 3px; }
  .p-dropdown .p-dropdown-clear-icon {
    color: #6c757d;
    right: 2.357rem; }
  .p-dropdown.p-error, .p-dropdown.p-invalid {
    border-color: #f44336; }

.p-dropdown-panel {
  background: #ffffff;
  color: #495057;
  border: 0 none;
  border-radius: 3px;
  -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-dropdown-panel .p-dropdown-header {
    padding: 0.5rem 1rem;
    border-bottom: 0 none;
    color: #495057;
    background: #f8f9fa;
    margin: 0;
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
    .p-dropdown-panel .p-dropdown-header .p-dropdown-filter {
      padding-right: 1.5rem; }
    .p-dropdown-panel .p-dropdown-header .p-dropdown-filter-icon {
      right: 0.5rem;
      color: #6c757d; }
  .p-dropdown-panel .p-dropdown-items {
    padding: 0.5rem 0; }
    .p-dropdown-panel .p-dropdown-items .p-dropdown-item {
      margin: 0;
      padding: 0.5rem 1rem;
      border: 0 none;
      color: #495057;
      background: transparent;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      border-radius: 0; }
      .p-dropdown-panel .p-dropdown-items .p-dropdown-item.p-highlight {
        color: #495057;
        background: #E3F2FD; }
      .p-dropdown-panel .p-dropdown-items .p-dropdown-item:not(.p-highlight):not(.p-disabled):hover {
        color: #495057;
        background: #e9ecef; }
    .p-dropdown-panel .p-dropdown-items .p-dropdown-empty-message {
      padding: 0.5rem 1rem;
      color: #495057;
      background: transparent; }

.p-input-filled .p-dropdown {
  background: #f8f9fa; }
  .p-input-filled .p-dropdown:not(.p-disabled):hover {
    background-color: #f8f9fa; }
  .p-input-filled .p-dropdown:not(.p-disabled).p-focus {
    background-color: #ffffff; }

.p-editor-container .p-editor-toolbar {
  background: #f8f9fa;
  border-top-right-radius: 3px;
  border-top-left-radius: 3px; }
  .p-editor-container .p-editor-toolbar.ql-snow {
    border: 1px solid #dee2e6; }
    .p-editor-container .p-editor-toolbar.ql-snow .ql-stroke {
      stroke: #6c757d; }
    .p-editor-container .p-editor-toolbar.ql-snow .ql-fill {
      fill: #6c757d; }
    .p-editor-container .p-editor-toolbar.ql-snow .ql-picker .ql-picker-label {
      border: 0 none;
      color: #6c757d; }
      .p-editor-container .p-editor-toolbar.ql-snow .ql-picker .ql-picker-label:hover {
        color: #495057; }
        .p-editor-container .p-editor-toolbar.ql-snow .ql-picker .ql-picker-label:hover .ql-stroke {
          stroke: #495057; }
        .p-editor-container .p-editor-toolbar.ql-snow .ql-picker .ql-picker-label:hover .ql-fill {
          fill: #495057; }
    .p-editor-container .p-editor-toolbar.ql-snow .ql-picker.ql-expanded .ql-picker-label {
      color: #495057; }
      .p-editor-container .p-editor-toolbar.ql-snow .ql-picker.ql-expanded .ql-picker-label .ql-stroke {
        stroke: #495057; }
      .p-editor-container .p-editor-toolbar.ql-snow .ql-picker.ql-expanded .ql-picker-label .ql-fill {
        fill: #495057; }
    .p-editor-container .p-editor-toolbar.ql-snow .ql-picker.ql-expanded .ql-picker-options {
      background: #ffffff;
      border: 0 none;
      -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
              box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
      border-radius: 3px; }
      .p-editor-container .p-editor-toolbar.ql-snow .ql-picker.ql-expanded .ql-picker-options .ql-picker-item {
        color: #495057;
        padding: 0.5rem 1rem;
        border-radius: 3px; }
        .p-editor-container .p-editor-toolbar.ql-snow .ql-picker.ql-expanded .ql-picker-options .ql-picker-item:hover {
          color: #495057;
          background: #e9ecef; }
.p-editor-container .p-editor-content {
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px; }
  .p-editor-container .p-editor-content.ql-snow {
    border: 1px solid #dee2e6; }
  .p-editor-container .p-editor-content .ql-editor {
    background: #ffffff;
    color: #495057;
    border-bottom-right-radius: 3px;
    border-bottom-left-radius: 3px; }
.p-editor-container .ql-snow.ql-toolbar button:hover,
.p-editor-container .ql-snow.ql-toolbar button:focus {
  color: #495057; }
  .p-editor-container .ql-snow.ql-toolbar button:hover .ql-stroke,
  .p-editor-container .ql-snow.ql-toolbar button:focus .ql-stroke {
    stroke: #495057; }
  .p-editor-container .ql-snow.ql-toolbar button:hover .ql-fill,
  .p-editor-container .ql-snow.ql-toolbar button:focus .ql-fill {
    fill: #495057; }
.p-editor-container .ql-snow.ql-toolbar button.ql-active,
.p-editor-container .ql-snow.ql-toolbar .ql-picker-label.ql-active,
.p-editor-container .ql-snow.ql-toolbar .ql-picker-item.ql-selected {
  color: #2196F3; }
  .p-editor-container .ql-snow.ql-toolbar button.ql-active .ql-stroke,
  .p-editor-container .ql-snow.ql-toolbar .ql-picker-label.ql-active .ql-stroke,
  .p-editor-container .ql-snow.ql-toolbar .ql-picker-item.ql-selected .ql-stroke {
    stroke: #2196F3; }
  .p-editor-container .ql-snow.ql-toolbar button.ql-active .ql-fill,
  .p-editor-container .ql-snow.ql-toolbar .ql-picker-label.ql-active .ql-fill,
  .p-editor-container .ql-snow.ql-toolbar .ql-picker-item.ql-selected .ql-fill {
    fill: #2196F3; }
  .p-editor-container .ql-snow.ql-toolbar button.ql-active .ql-picker-label,
  .p-editor-container .ql-snow.ql-toolbar .ql-picker-label.ql-active .ql-picker-label,
  .p-editor-container .ql-snow.ql-toolbar .ql-picker-item.ql-selected .ql-picker-label {
    color: #2196F3; }

.p-inputgroup-addon {
  background: #e9ecef;
  color: #6c757d;
  border-top: 1px solid #ced4da;
  border-left: 1px solid #ced4da;
  border-bottom: 1px solid #ced4da;
  padding: 0.5rem 0.5rem;
  min-width: 2.357rem; }
  .p-inputgroup-addon:last-child {
    border-right: 1px solid #ced4da; }

.p-inputgroup > .p-component,
.p-inputgroup > .p-inputwrapper > .p-inputtext,
.p-inputgroup > .p-float-label > .p-component {
  border-radius: 0;
  margin: 0; }
  .p-inputgroup > .p-component + .p-inputgroup-addon,
  .p-inputgroup > .p-inputwrapper > .p-inputtext + .p-inputgroup-addon,
  .p-inputgroup > .p-float-label > .p-component + .p-inputgroup-addon {
    border-left: 0 none; }
  .p-inputgroup > .p-component:focus,
  .p-inputgroup > .p-inputwrapper > .p-inputtext:focus,
  .p-inputgroup > .p-float-label > .p-component:focus {
    z-index: 1; }
    .p-inputgroup > .p-component:focus ~ label,
    .p-inputgroup > .p-inputwrapper > .p-inputtext:focus ~ label,
    .p-inputgroup > .p-float-label > .p-component:focus ~ label {
      z-index: 1; }

.p-inputgroup-addon:first-child,
.p-inputgroup button:first-child,
.p-inputgroup input:first-child,
.p-inputgroup > .p-inputwrapper:first-child,
.p-inputgroup > .p-inputwrapper:first-child > .p-inputtext {
  border-top-left-radius: 3px;
  border-bottom-left-radius: 3px; }

.p-inputgroup .p-float-label:first-child input {
  border-top-left-radius: 3px;
  border-bottom-left-radius: 3px; }

.p-inputgroup-addon:last-child,
.p-inputgroup button:last-child,
.p-inputgroup input:last-child,
.p-inputgroup > .p-inputwrapper:last-child,
.p-inputgroup > .p-inputwrapper:last-child > .p-inputtext {
  border-top-right-radius: 3px;
  border-bottom-right-radius: 3px; }

.p-inputgroup .p-float-label:last-child input {
  border-top-right-radius: 3px;
  border-bottom-right-radius: 3px; }

.p-fluid .p-inputgroup .p-button {
  width: auto; }
  .p-fluid .p-inputgroup .p-button.p-button-icon-only {
    width: 2.357rem; }

.p-inputnumber.p-error > .p-inputtext, .p-inputnumber.p-invalid > .p-inputtext {
  border-color: #f44336; }

.p-inputswitch {
  width: 3rem;
  height: 1.75rem; }
  .p-inputswitch .p-inputswitch-slider {
    background: #ced4da;
    -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
    border-radius: 30px; }
    .p-inputswitch .p-inputswitch-slider:before {
      background: #ffffff;
      width: 1.25rem;
      height: 1.25rem;
      left: 0.25rem;
      margin-top: -0.625rem;
      border-radius: 50%;
      -webkit-transition-duration: 0.2s;
              transition-duration: 0.2s; }
  .p-inputswitch.p-inputswitch-checked .p-inputswitch-slider:before {
    -webkit-transform: translateX(1.25rem);
            transform: translateX(1.25rem); }
  .p-inputswitch.p-focus .p-inputswitch-slider {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .p-inputswitch:not(.p-disabled):hover .p-inputswitch-slider {
    background: #b6bfc8; }
  .p-inputswitch.p-inputswitch-checked .p-inputswitch-slider {
    background: #2196F3; }
    .p-inputswitch.p-inputswitch-checked .p-inputswitch-slider:before {
      background: #ffffff; }
  .p-inputswitch.p-inputswitch-checked:not(.p-disabled):hover .p-inputswitch-slider {
    background: #0d89ec; }
  .p-inputswitch.p-error, .p-inputswitch.p-invalid {
    border-color: #f44336; }

.p-inputtext {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
  font-size: 1rem;
  color: #495057;
  background: #ffffff;
  padding: 0.5rem 0.5rem;
  border: 1px solid #ced4da;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  -webkit-appearance: none;
     -moz-appearance: none;
          appearance: none;
  border-radius: 3px; }
  .p-inputtext:enabled:hover {
    border-color: #2196F3; }
  .p-inputtext:enabled:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa;
    border-color: #2196F3; }
  .p-inputtext.p-error, .p-inputtext.p-invalid {
    border-color: #f44336; }
  .p-inputtext.p-inputtext-sm {
    font-size: 0.875rem;
    padding: 0.4375rem 0.4375rem; }
  .p-inputtext.p-inputtext-lg {
    font-size: 1.25rem;
    padding: 0.625rem 0.625rem; }

.p-float-label > label {
  left: 0.5rem;
  color: #6c757d;
  -webkit-transition-duration: 0.2s;
          transition-duration: 0.2s; }

.p-input-icon-left > i:first-of-type {
  left: 0.5rem;
  color: #6c757d; }

.p-input-icon-left > .p-inputtext {
  padding-left: 2rem; }

.p-input-icon-right > i:last-of-type {
  right: 0.5rem;
  color: #6c757d; }

.p-input-icon-right > .p-inputtext {
  padding-right: 2rem; }

::-webkit-input-placeholder {
  color: #6c757d; }

:-moz-placeholder {
  color: #6c757d; }

::-moz-placeholder {
  color: #6c757d; }

:-ms-input-placeholder {
  color: #6c757d; }

.p-input-filled .p-inputtext {
  background-color: #f8f9fa; }
  .p-input-filled .p-inputtext:enabled:hover {
    background-color: #f8f9fa; }
  .p-input-filled .p-inputtext:enabled:focus {
    background-color: #ffffff; }

.p-inputtext-sm .p-inputtext {
  font-size: 0.875rem;
  padding: 0.4375rem 0.4375rem; }

.p-inputtext-lg .p-inputtext {
  font-size: 1.25rem;
  padding: 0.625rem 0.625rem; }

.p-listbox {
  background: #ffffff;
  color: #495057;
  border: 1px solid #ced4da;
  border-radius: 3px; }
  .p-listbox .p-listbox-header {
    padding: 0.5rem 1rem;
    border-bottom: 0 none;
    color: #495057;
    background: #f8f9fa;
    margin: 0;
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
    .p-listbox .p-listbox-header .p-listbox-filter {
      padding-right: 1.5rem; }
    .p-listbox .p-listbox-header .p-listbox-filter-icon {
      right: 0.5rem;
      color: #6c757d; }
  .p-listbox .p-listbox-list {
    padding: 0.5rem 0; }
    .p-listbox .p-listbox-list .p-listbox-item {
      margin: 0;
      padding: 0.5rem 1rem;
      border: 0 none;
      color: #495057;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      border-radius: 0; }
      .p-listbox .p-listbox-list .p-listbox-item.p-highlight {
        color: #495057;
        background: #E3F2FD; }
      .p-listbox .p-listbox-list .p-listbox-item:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
                box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
    .p-listbox .p-listbox-list .p-listbox-empty-message {
      padding: 0.5rem 1rem;
      color: #495057;
      background: transparent; }
  .p-listbox:not(.p-disabled) .p-listbox-item:not(.p-highlight):not(.p-disabled):hover {
    color: #495057;
    background: #e9ecef; }
  .p-listbox.p-error, .p-listbox.p-invalid {
    border-color: #f44336; }

.p-multiselect {
  background: #ffffff;
  border: 1px solid #ced4da;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  border-radius: 3px; }
  .p-multiselect:not(.p-disabled):hover {
    border-color: #2196F3; }
  .p-multiselect:not(.p-disabled).p-focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa;
    border-color: #2196F3; }
  .p-multiselect .p-multiselect-label {
    padding: 0.5rem 0.5rem;
    -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-multiselect .p-multiselect-label.p-placeholder {
      color: #6c757d; }
  .p-multiselect .p-multiselect-trigger {
    background: transparent;
    color: #6c757d;
    width: 2.357rem;
    border-top-right-radius: 3px;
    border-bottom-right-radius: 3px; }
  .p-multiselect.p-error, .p-multiselect.p-invalid {
    border-color: #f44336; }

.p-multiselect-panel {
  background: #ffffff;
  color: #495057;
  border: 0 none;
  border-radius: 3px;
  -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-multiselect-panel .p-multiselect-header {
    padding: 0.5rem 1rem;
    border-bottom: 0 none;
    color: #495057;
    background: #f8f9fa;
    margin: 0;
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
    .p-multiselect-panel .p-multiselect-header .p-multiselect-filter-container .p-inputtext {
      padding-right: 1.5rem; }
    .p-multiselect-panel .p-multiselect-header .p-multiselect-filter-container .p-multiselect-filter-icon {
      right: 0.5rem;
      color: #6c757d; }
    .p-multiselect-panel .p-multiselect-header .p-checkbox {
      margin-right: 0.5rem; }
    .p-multiselect-panel .p-multiselect-header .p-multiselect-close {
      margin-left: 0.5rem;
      width: 2rem;
      height: 2rem;
      color: #6c757d;
      border: 0 none;
      background: transparent;
      border-radius: 50%;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
      .p-multiselect-panel .p-multiselect-header .p-multiselect-close:enabled:hover {
        color: #495057;
        border-color: transparent;
        background: #e9ecef; }
      .p-multiselect-panel .p-multiselect-header .p-multiselect-close:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .p-multiselect-panel .p-multiselect-items {
    padding: 0.5rem 0; }
    .p-multiselect-panel .p-multiselect-items .p-multiselect-item {
      margin: 0;
      padding: 0.5rem 1rem;
      border: 0 none;
      color: #495057;
      background: transparent;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      border-radius: 0; }
      .p-multiselect-panel .p-multiselect-items .p-multiselect-item.p-highlight {
        color: #495057;
        background: #E3F2FD; }
      .p-multiselect-panel .p-multiselect-items .p-multiselect-item:not(.p-highlight):not(.p-disabled):hover {
        color: #495057;
        background: #e9ecef; }
      .p-multiselect-panel .p-multiselect-items .p-multiselect-item:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
                box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
      .p-multiselect-panel .p-multiselect-items .p-multiselect-item .p-checkbox {
        margin-right: 0.5rem; }
    .p-multiselect-panel .p-multiselect-items .p-multiselect-empty-message {
      padding: 0.5rem 1rem;
      color: #495057;
      background: transparent; }

.p-input-filled .p-multiselect {
  background: #f8f9fa; }
  .p-input-filled .p-multiselect:not(.p-disabled):hover {
    background-color: #f8f9fa; }
  .p-input-filled .p-multiselect:not(.p-disabled).p-focus {
    background-color: #ffffff; }

.p-password-panel {
  padding: 1rem;
  background: #ffffff;
  color: #495057;
  border: 0 none;
  -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
  border-radius: 3px; }
  .p-password-panel .p-password-meter {
    margin-bottom: 0.5rem; }

.p-radiobutton {
  width: 20px;
  height: 20px; }
  .p-radiobutton .p-radiobutton-box {
    border: 2px solid #ced4da;
    background: #ffffff;
    width: 20px;
    height: 20px;
    color: #495057;
    border-radius: 50%;
    -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-radiobutton .p-radiobutton-box:not(.p-disabled):not(.p-highlight):hover {
      border-color: #2196F3; }
    .p-radiobutton .p-radiobutton-box:not(.p-disabled).p-focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa;
      border-color: #2196F3; }
    .p-radiobutton .p-radiobutton-box .p-radiobutton-icon {
      width: 12px;
      height: 12px;
      -webkit-transition-duration: 0.2s;
              transition-duration: 0.2s;
      background-color: #ffffff; }
    .p-radiobutton .p-radiobutton-box.p-highlight {
      border-color: #2196F3;
      background: #2196F3; }
      .p-radiobutton .p-radiobutton-box.p-highlight:not(.p-disabled):hover {
        border-color: #0b7ad1;
        background: #0b7ad1;
        color: #ffffff; }
  .p-radiobutton.p-error > .p-radiobutton-box, .p-radiobutton.p-invalid > .p-radiobutton-box {
    border-color: #f44336; }

.p-input-filled .p-radiobutton .p-radiobutton-box {
  background-color: #f8f9fa; }
  .p-input-filled .p-radiobutton .p-radiobutton-box:not(.p-disabled):hover {
    background-color: #f8f9fa; }
  .p-input-filled .p-radiobutton .p-radiobutton-box.p-highlight {
    background: #2196F3; }
    .p-input-filled .p-radiobutton .p-radiobutton-box.p-highlight:not(.p-disabled):hover {
      background: #0b7ad1; }

.p-rating .p-rating-icon {
  color: #495057;
  margin-left: 0.5rem;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  font-size: 1.143rem; }
  .p-rating .p-rating-icon.p-rating-cancel {
    color: #e74c3c; }
  .p-rating .p-rating-icon:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .p-rating .p-rating-icon:first-child {
    margin-left: 0; }
  .p-rating .p-rating-icon.pi-star {
    color: #2196F3; }
.p-rating:not(.p-disabled):not(.p-readonly) .p-rating-icon:hover {
  color: #2196F3; }
.p-rating:not(.p-disabled):not(.p-readonly) .p-rating-icon.p-rating-cancel:hover {
  color: #c0392b; }

.p-selectbutton .p-button {
  background: #ffffff;
  border: 1px solid #ced4da;
  color: #495057;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
  .p-selectbutton .p-button .p-button-icon-left,
  .p-selectbutton .p-button .p-button-icon-right {
    color: #6c757d; }
  .p-selectbutton .p-button:not(.p-disabled):not(.p-highlight):hover {
    background: #e9ecef;
    border-color: #ced4da;
    color: #495057; }
    .p-selectbutton .p-button:not(.p-disabled):not(.p-highlight):hover .p-button-icon-left,
    .p-selectbutton .p-button:not(.p-disabled):not(.p-highlight):hover .p-button-icon-right {
      color: #6c757d; }
  .p-selectbutton .p-button.p-highlight {
    background: #2196F3;
    border-color: #2196F3;
    color: #ffffff; }
    .p-selectbutton .p-button.p-highlight .p-button-icon-left,
    .p-selectbutton .p-button.p-highlight .p-button-icon-right {
      color: #ffffff; }
    .p-selectbutton .p-button.p-highlight:hover {
      background: #0d89ec;
      border-color: #0d89ec;
      color: #ffffff; }
      .p-selectbutton .p-button.p-highlight:hover .p-button-icon-left,
      .p-selectbutton .p-button.p-highlight:hover .p-button-icon-right {
        color: #ffffff; }
.p-selectbutton.p-error > .p-button, .p-selectbutton.p-invalid > .p-button {
  border-color: #f44336; }

.p-slider {
  background: #dee2e6;
  border: 0 none;
  border-radius: 3px; }
  .p-slider.p-slider-horizontal {
    height: 0.286rem; }
    .p-slider.p-slider-horizontal .p-slider-handle {
      margin-top: -0.5715rem;
      margin-left: -0.5715rem; }
  .p-slider.p-slider-vertical {
    width: 0.286rem; }
    .p-slider.p-slider-vertical .p-slider-handle {
      margin-left: -0.5715rem;
      margin-bottom: -0.5715rem; }
  .p-slider .p-slider-handle {
    height: 1.143rem;
    width: 1.143rem;
    background: #ffffff;
    border: 2px solid #2196F3;
    border-radius: 50%;
    -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-slider .p-slider-handle:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .p-slider .p-slider-range {
    background: #2196F3; }
  .p-slider:not(.p-disabled) .p-slider-handle:hover {
    background: #2196F3;
    border-color: #2196F3; }

.p-togglebutton.p-button {
  background: #ffffff;
  border: 1px solid #ced4da;
  color: #495057;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
  .p-togglebutton.p-button .p-button-icon-left,
  .p-togglebutton.p-button .p-button-icon-right {
    color: #6c757d; }
  .p-togglebutton.p-button:not(.p-disabled):not(.p-highlight):hover {
    background: #e9ecef;
    border-color: #ced4da;
    color: #495057; }
    .p-togglebutton.p-button:not(.p-disabled):not(.p-highlight):hover .p-button-icon-left,
    .p-togglebutton.p-button:not(.p-disabled):not(.p-highlight):hover .p-button-icon-right {
      color: #6c757d; }
  .p-togglebutton.p-button.p-highlight {
    background: #2196F3;
    border-color: #2196F3;
    color: #ffffff; }
    .p-togglebutton.p-button.p-highlight .p-button-icon-left,
    .p-togglebutton.p-button.p-highlight .p-button-icon-right {
      color: #ffffff; }
    .p-togglebutton.p-button.p-highlight:hover {
      background: #0d89ec;
      border-color: #0d89ec;
      color: #ffffff; }
      .p-togglebutton.p-button.p-highlight:hover .p-button-icon-left,
      .p-togglebutton.p-button.p-highlight:hover .p-button-icon-right {
        color: #ffffff; }
  .p-togglebutton.p-button.p-error > .p-button, .p-togglebutton.p-button.p-invalid > .p-button {
    border-color: #f44336; }

.p-button {
  color: #ffffff;
  background: #2196F3;
  border: 1px solid #2196F3;
  padding: 0.5rem 1rem;
  font-size: 1rem;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  border-radius: 3px; }
  .p-button:enabled:hover {
    background: #0d89ec;
    color: #ffffff;
    border-color: #0d89ec; }
  .p-button:enabled:active {
    background: #0b7ad1;
    color: #ffffff;
    border-color: #0b7ad1; }
  .p-button.p-button-outlined {
    background-color: transparent;
    color: #2196F3;
    border: 1px solid; }
    .p-button.p-button-outlined:enabled:hover {
      background: rgba(33, 150, 243, 0.04);
      color: #2196F3;
      border: 1px solid; }
    .p-button.p-button-outlined:enabled:active {
      background: rgba(33, 150, 243, 0.16);
      color: #2196F3;
      border: 1px solid; }
  .p-button.p-button-text {
    background-color: transparent;
    color: #2196F3;
    border-color: transparent; }
    .p-button.p-button-text:enabled:hover {
      background: rgba(33, 150, 243, 0.04);
      color: #2196F3;
      border-color: transparent; }
    .p-button.p-button-text:enabled:active {
      background: rgba(33, 150, 243, 0.16);
      color: #2196F3;
      border-color: transparent; }
    .p-button.p-button-text.p-button-plain {
      color: #6c757d; }
      .p-button.p-button-text.p-button-plain:enabled:hover {
        background: #e9ecef;
        color: #6c757d; }
      .p-button.p-button-text.p-button-plain:enabled:active {
        background: #dee2e6;
        color: #6c757d; }
  .p-button:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .p-button .p-button-icon-left {
    margin-right: 0.5rem; }
  .p-button .p-button-icon-right {
    margin-left: 0.5rem; }
  .p-button .p-button-icon-bottom {
    margin-top: 0.5rem; }
  .p-button .p-button-icon-top {
    margin-bottom: 0.5rem; }
  .p-button .p-badge {
    margin-left: 0.5rem;
    min-width: 1rem;
    height: 1rem;
    line-height: 1rem;
    color: #2196F3;
    background-color: #ffffff; }
  .p-button.p-button-raised {
    -webkit-box-shadow: 0 3px 1px -2px rgba(0, 0, 0, 0.2), 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 1px 5px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 3px 1px -2px rgba(0, 0, 0, 0.2), 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 1px 5px 0 rgba(0, 0, 0, 0.12); }
  .p-button.p-button-rounded {
    border-radius: 2rem; }
  .p-button.p-button-icon-only {
    width: 2.357rem;
    padding: 0.5rem 0; }
    .p-button.p-button-icon-only .p-button-icon-left,
    .p-button.p-button-icon-only .p-button-icon-right {
      margin: 0; }
    .p-button.p-button-icon-only.p-button-rounded {
      border-radius: 50%;
      height: 2.357rem; }
  .p-button.p-button-sm {
    font-size: 0.875rem;
    padding: 0.4375rem 0.875rem; }
    .p-button.p-button-sm .p-button-icon {
      font-size: 0.875rem; }
  .p-button.p-button-lg {
    font-size: 1.25rem;
    padding: 0.625rem 1.25rem; }
    .p-button.p-button-lg .p-button-icon {
      font-size: 1.25rem; }

.p-fluid .p-button {
  width: 100%; }
.p-fluid .p-button-icon-only {
  width: 2.357rem; }
.p-fluid .p-buttonset {
  display: -ms-flexbox;
  display: flex; }
  .p-fluid .p-buttonset .p-button {
    -ms-flex: 1 1;
        flex: 1 1; }

.p-button.p-button-secondary, .p-buttonset.p-button-secondary > .p-button, .p-splitbutton.p-button-secondary > .p-button {
  color: #ffffff;
  background: #607D8B;
  border: 1px solid #607D8B; }
  .p-button.p-button-secondary:enabled:hover, .p-buttonset.p-button-secondary > .p-button:enabled:hover, .p-splitbutton.p-button-secondary > .p-button:enabled:hover {
    background: #56717d;
    color: #ffffff;
    border-color: #56717d; }
  .p-button.p-button-secondary:enabled:focus, .p-buttonset.p-button-secondary > .p-button:enabled:focus, .p-splitbutton.p-button-secondary > .p-button:enabled:focus {
    -webkit-box-shadow: 0 0 0 0.2rem #beccd2;
            box-shadow: 0 0 0 0.2rem #beccd2; }
  .p-button.p-button-secondary:enabled:active, .p-buttonset.p-button-secondary > .p-button:enabled:active, .p-splitbutton.p-button-secondary > .p-button:enabled:active {
    background: #4d646f;
    color: #ffffff;
    border-color: #4d646f; }
  .p-button.p-button-secondary.p-button-outlined, .p-buttonset.p-button-secondary > .p-button.p-button-outlined, .p-splitbutton.p-button-secondary > .p-button.p-button-outlined {
    background-color: transparent;
    color: #607D8B;
    border: 1px solid; }
    .p-button.p-button-secondary.p-button-outlined:enabled:hover, .p-buttonset.p-button-secondary > .p-button.p-button-outlined:enabled:hover, .p-splitbutton.p-button-secondary > .p-button.p-button-outlined:enabled:hover {
      background: rgba(96, 125, 139, 0.04);
      color: #607D8B;
      border: 1px solid; }
    .p-button.p-button-secondary.p-button-outlined:enabled:active, .p-buttonset.p-button-secondary > .p-button.p-button-outlined:enabled:active, .p-splitbutton.p-button-secondary > .p-button.p-button-outlined:enabled:active {
      background: rgba(96, 125, 139, 0.16);
      color: #607D8B;
      border: 1px solid; }
  .p-button.p-button-secondary.p-button-text, .p-buttonset.p-button-secondary > .p-button.p-button-text, .p-splitbutton.p-button-secondary > .p-button.p-button-text {
    background-color: transparent;
    color: #607D8B;
    border-color: transparent; }
    .p-button.p-button-secondary.p-button-text:enabled:hover, .p-buttonset.p-button-secondary > .p-button.p-button-text:enabled:hover, .p-splitbutton.p-button-secondary > .p-button.p-button-text:enabled:hover {
      background: rgba(96, 125, 139, 0.04);
      border-color: transparent;
      color: #607D8B; }
    .p-button.p-button-secondary.p-button-text:enabled:active, .p-buttonset.p-button-secondary > .p-button.p-button-text:enabled:active, .p-splitbutton.p-button-secondary > .p-button.p-button-text:enabled:active {
      background: rgba(96, 125, 139, 0.16);
      border-color: transparent;
      color: #607D8B; }

.p-button.p-button-info, .p-buttonset.p-button-info > .p-button, .p-splitbutton.p-button-info > .p-button {
  color: #ffffff;
  background: #0288D1;
  border: 1px solid #0288D1; }
  .p-button.p-button-info:enabled:hover, .p-buttonset.p-button-info > .p-button:enabled:hover, .p-splitbutton.p-button-info > .p-button:enabled:hover {
    background: #027abc;
    color: #ffffff;
    border-color: #027abc; }
  .p-button.p-button-info:enabled:focus, .p-buttonset.p-button-info > .p-button:enabled:focus, .p-splitbutton.p-button-info > .p-button:enabled:focus {
    -webkit-box-shadow: 0 0 0 0.2rem #89d4fe;
            box-shadow: 0 0 0 0.2rem #89d4fe; }
  .p-button.p-button-info:enabled:active, .p-buttonset.p-button-info > .p-button:enabled:active, .p-splitbutton.p-button-info > .p-button:enabled:active {
    background: #026da7;
    color: #ffffff;
    border-color: #026da7; }
  .p-button.p-button-info.p-button-outlined, .p-buttonset.p-button-info > .p-button.p-button-outlined, .p-splitbutton.p-button-info > .p-button.p-button-outlined {
    background-color: transparent;
    color: #0288D1;
    border: 1px solid; }
    .p-button.p-button-info.p-button-outlined:enabled:hover, .p-buttonset.p-button-info > .p-button.p-button-outlined:enabled:hover, .p-splitbutton.p-button-info > .p-button.p-button-outlined:enabled:hover {
      background: rgba(2, 136, 209, 0.04);
      color: #0288D1;
      border: 1px solid; }
    .p-button.p-button-info.p-button-outlined:enabled:active, .p-buttonset.p-button-info > .p-button.p-button-outlined:enabled:active, .p-splitbutton.p-button-info > .p-button.p-button-outlined:enabled:active {
      background: rgba(2, 136, 209, 0.16);
      color: #0288D1;
      border: 1px solid; }
  .p-button.p-button-info.p-button-text, .p-buttonset.p-button-info > .p-button.p-button-text, .p-splitbutton.p-button-info > .p-button.p-button-text {
    background-color: transparent;
    color: #0288D1;
    border-color: transparent; }
    .p-button.p-button-info.p-button-text:enabled:hover, .p-buttonset.p-button-info > .p-button.p-button-text:enabled:hover, .p-splitbutton.p-button-info > .p-button.p-button-text:enabled:hover {
      background: rgba(2, 136, 209, 0.04);
      border-color: transparent;
      color: #0288D1; }
    .p-button.p-button-info.p-button-text:enabled:active, .p-buttonset.p-button-info > .p-button.p-button-text:enabled:active, .p-splitbutton.p-button-info > .p-button.p-button-text:enabled:active {
      background: rgba(2, 136, 209, 0.16);
      border-color: transparent;
      color: #0288D1; }

.p-button.p-button-success, .p-buttonset.p-button-success > .p-button, .p-splitbutton.p-button-success > .p-button {
  color: #ffffff;
  background: #689F38;
  border: 1px solid #689F38; }
  .p-button.p-button-success:enabled:hover, .p-buttonset.p-button-success > .p-button:enabled:hover, .p-splitbutton.p-button-success > .p-button:enabled:hover {
    background: #5e8f32;
    color: #ffffff;
    border-color: #5e8f32; }
  .p-button.p-button-success:enabled:focus, .p-buttonset.p-button-success > .p-button:enabled:focus, .p-splitbutton.p-button-success > .p-button:enabled:focus {
    -webkit-box-shadow: 0 0 0 0.2rem #c2e0a8;
            box-shadow: 0 0 0 0.2rem #c2e0a8; }
  .p-button.p-button-success:enabled:active, .p-buttonset.p-button-success > .p-button:enabled:active, .p-splitbutton.p-button-success > .p-button:enabled:active {
    background: #537f2d;
    color: #ffffff;
    border-color: #537f2d; }
  .p-button.p-button-success.p-button-outlined, .p-buttonset.p-button-success > .p-button.p-button-outlined, .p-splitbutton.p-button-success > .p-button.p-button-outlined {
    background-color: transparent;
    color: #689F38;
    border: 1px solid; }
    .p-button.p-button-success.p-button-outlined:enabled:hover, .p-buttonset.p-button-success > .p-button.p-button-outlined:enabled:hover, .p-splitbutton.p-button-success > .p-button.p-button-outlined:enabled:hover {
      background: rgba(104, 159, 56, 0.04);
      color: #689F38;
      border: 1px solid; }
    .p-button.p-button-success.p-button-outlined:enabled:active, .p-buttonset.p-button-success > .p-button.p-button-outlined:enabled:active, .p-splitbutton.p-button-success > .p-button.p-button-outlined:enabled:active {
      background: rgba(104, 159, 56, 0.16);
      color: #689F38;
      border: 1px solid; }
  .p-button.p-button-success.p-button-text, .p-buttonset.p-button-success > .p-button.p-button-text, .p-splitbutton.p-button-success > .p-button.p-button-text {
    background-color: transparent;
    color: #689F38;
    border-color: transparent; }
    .p-button.p-button-success.p-button-text:enabled:hover, .p-buttonset.p-button-success > .p-button.p-button-text:enabled:hover, .p-splitbutton.p-button-success > .p-button.p-button-text:enabled:hover {
      background: rgba(104, 159, 56, 0.04);
      border-color: transparent;
      color: #689F38; }
    .p-button.p-button-success.p-button-text:enabled:active, .p-buttonset.p-button-success > .p-button.p-button-text:enabled:active, .p-splitbutton.p-button-success > .p-button.p-button-text:enabled:active {
      background: rgba(104, 159, 56, 0.16);
      border-color: transparent;
      color: #689F38; }

.p-button.p-button-warning, .p-buttonset.p-button-warning > .p-button, .p-splitbutton.p-button-warning > .p-button {
  color: #212529;
  background: #FBC02D;
  border: 1px solid #FBC02D; }
  .p-button.p-button-warning:enabled:hover, .p-buttonset.p-button-warning > .p-button:enabled:hover, .p-splitbutton.p-button-warning > .p-button:enabled:hover {
    background: #fab710;
    color: #212529;
    border-color: #fab710; }
  .p-button.p-button-warning:enabled:focus, .p-buttonset.p-button-warning > .p-button:enabled:focus, .p-splitbutton.p-button-warning > .p-button:enabled:focus {
    -webkit-box-shadow: 0 0 0 0.2rem #fde6ab;
            box-shadow: 0 0 0 0.2rem #fde6ab; }
  .p-button.p-button-warning:enabled:active, .p-buttonset.p-button-warning > .p-button:enabled:active, .p-splitbutton.p-button-warning > .p-button:enabled:active {
    background: #e8a704;
    color: #212529;
    border-color: #e8a704; }
  .p-button.p-button-warning.p-button-outlined, .p-buttonset.p-button-warning > .p-button.p-button-outlined, .p-splitbutton.p-button-warning > .p-button.p-button-outlined {
    background-color: transparent;
    color: #FBC02D;
    border: 1px solid; }
    .p-button.p-button-warning.p-button-outlined:enabled:hover, .p-buttonset.p-button-warning > .p-button.p-button-outlined:enabled:hover, .p-splitbutton.p-button-warning > .p-button.p-button-outlined:enabled:hover {
      background: rgba(251, 192, 45, 0.04);
      color: #FBC02D;
      border: 1px solid; }
    .p-button.p-button-warning.p-button-outlined:enabled:active, .p-buttonset.p-button-warning > .p-button.p-button-outlined:enabled:active, .p-splitbutton.p-button-warning > .p-button.p-button-outlined:enabled:active {
      background: rgba(251, 192, 45, 0.16);
      color: #FBC02D;
      border: 1px solid; }
  .p-button.p-button-warning.p-button-text, .p-buttonset.p-button-warning > .p-button.p-button-text, .p-splitbutton.p-button-warning > .p-button.p-button-text {
    background-color: transparent;
    color: #FBC02D;
    border-color: transparent; }
    .p-button.p-button-warning.p-button-text:enabled:hover, .p-buttonset.p-button-warning > .p-button.p-button-text:enabled:hover, .p-splitbutton.p-button-warning > .p-button.p-button-text:enabled:hover {
      background: rgba(251, 192, 45, 0.04);
      border-color: transparent;
      color: #FBC02D; }
    .p-button.p-button-warning.p-button-text:enabled:active, .p-buttonset.p-button-warning > .p-button.p-button-text:enabled:active, .p-splitbutton.p-button-warning > .p-button.p-button-text:enabled:active {
      background: rgba(251, 192, 45, 0.16);
      border-color: transparent;
      color: #FBC02D; }

.p-button.p-button-help, .p-buttonset.p-button-help > .p-button, .p-splitbutton.p-button-help > .p-button {
  color: #ffffff;
  background: #9C27B0;
  border: 1px solid #9C27B0; }
  .p-button.p-button-help:enabled:hover, .p-buttonset.p-button-help > .p-button:enabled:hover, .p-splitbutton.p-button-help > .p-button:enabled:hover {
    background: #8c239e;
    color: #ffffff;
    border-color: #8c239e; }
  .p-button.p-button-help:enabled:focus, .p-buttonset.p-button-help > .p-button:enabled:focus, .p-splitbutton.p-button-help > .p-button:enabled:focus {
    -webkit-box-shadow: 0 0 0 0.2rem #df9eea;
            box-shadow: 0 0 0 0.2rem #df9eea; }
  .p-button.p-button-help:enabled:active, .p-buttonset.p-button-help > .p-button:enabled:active, .p-splitbutton.p-button-help > .p-button:enabled:active {
    background: #7d1f8d;
    color: #ffffff;
    border-color: #7d1f8d; }
  .p-button.p-button-help.p-button-outlined, .p-buttonset.p-button-help > .p-button.p-button-outlined, .p-splitbutton.p-button-help > .p-button.p-button-outlined {
    background-color: transparent;
    color: #9C27B0;
    border: 1px solid; }
    .p-button.p-button-help.p-button-outlined:enabled:hover, .p-buttonset.p-button-help > .p-button.p-button-outlined:enabled:hover, .p-splitbutton.p-button-help > .p-button.p-button-outlined:enabled:hover {
      background: rgba(156, 39, 176, 0.04);
      color: #9C27B0;
      border: 1px solid; }
    .p-button.p-button-help.p-button-outlined:enabled:active, .p-buttonset.p-button-help > .p-button.p-button-outlined:enabled:active, .p-splitbutton.p-button-help > .p-button.p-button-outlined:enabled:active {
      background: rgba(156, 39, 176, 0.16);
      color: #9C27B0;
      border: 1px solid; }
  .p-button.p-button-help.p-button-text, .p-buttonset.p-button-help > .p-button.p-button-text, .p-splitbutton.p-button-help > .p-button.p-button-text {
    background-color: transparent;
    color: #9C27B0;
    border-color: transparent; }
    .p-button.p-button-help.p-button-text:enabled:hover, .p-buttonset.p-button-help > .p-button.p-button-text:enabled:hover, .p-splitbutton.p-button-help > .p-button.p-button-text:enabled:hover {
      background: rgba(156, 39, 176, 0.04);
      border-color: transparent;
      color: #9C27B0; }
    .p-button.p-button-help.p-button-text:enabled:active, .p-buttonset.p-button-help > .p-button.p-button-text:enabled:active, .p-splitbutton.p-button-help > .p-button.p-button-text:enabled:active {
      background: rgba(156, 39, 176, 0.16);
      border-color: transparent;
      color: #9C27B0; }

.p-button.p-button-danger, .p-buttonset.p-button-danger > .p-button, .p-splitbutton.p-button-danger > .p-button {
  color: #ffffff;
  background: #D32F2F;
  border: 1px solid #D32F2F; }
  .p-button.p-button-danger:enabled:hover, .p-buttonset.p-button-danger > .p-button:enabled:hover, .p-splitbutton.p-button-danger > .p-button:enabled:hover {
    background: #c02929;
    color: #ffffff;
    border-color: #c02929; }
  .p-button.p-button-danger:enabled:focus, .p-buttonset.p-button-danger > .p-button:enabled:focus, .p-splitbutton.p-button-danger > .p-button:enabled:focus {
    -webkit-box-shadow: 0 0 0 0.2rem #edacac;
            box-shadow: 0 0 0 0.2rem #edacac; }
  .p-button.p-button-danger:enabled:active, .p-buttonset.p-button-danger > .p-button:enabled:active, .p-splitbutton.p-button-danger > .p-button:enabled:active {
    background: #aa2424;
    color: #ffffff;
    border-color: #aa2424; }
  .p-button.p-button-danger.p-button-outlined, .p-buttonset.p-button-danger > .p-button.p-button-outlined, .p-splitbutton.p-button-danger > .p-button.p-button-outlined {
    background-color: transparent;
    color: #D32F2F;
    border: 1px solid; }
    .p-button.p-button-danger.p-button-outlined:enabled:hover, .p-buttonset.p-button-danger > .p-button.p-button-outlined:enabled:hover, .p-splitbutton.p-button-danger > .p-button.p-button-outlined:enabled:hover {
      background: rgba(211, 47, 47, 0.04);
      color: #D32F2F;
      border: 1px solid; }
    .p-button.p-button-danger.p-button-outlined:enabled:active, .p-buttonset.p-button-danger > .p-button.p-button-outlined:enabled:active, .p-splitbutton.p-button-danger > .p-button.p-button-outlined:enabled:active {
      background: rgba(211, 47, 47, 0.16);
      color: #D32F2F;
      border: 1px solid; }
  .p-button.p-button-danger.p-button-text, .p-buttonset.p-button-danger > .p-button.p-button-text, .p-splitbutton.p-button-danger > .p-button.p-button-text {
    background-color: transparent;
    color: #D32F2F;
    border-color: transparent; }
    .p-button.p-button-danger.p-button-text:enabled:hover, .p-buttonset.p-button-danger > .p-button.p-button-text:enabled:hover, .p-splitbutton.p-button-danger > .p-button.p-button-text:enabled:hover {
      background: rgba(211, 47, 47, 0.04);
      border-color: transparent;
      color: #D32F2F; }
    .p-button.p-button-danger.p-button-text:enabled:active, .p-buttonset.p-button-danger > .p-button.p-button-text:enabled:active, .p-splitbutton.p-button-danger > .p-button.p-button-text:enabled:active {
      background: rgba(211, 47, 47, 0.16);
      border-color: transparent;
      color: #D32F2F; }

.p-button.p-button-link {
  color: #0b7ad1;
  background: transparent;
  border: transparent; }
  .p-button.p-button-link:enabled:hover {
    background: transparent;
    color: #0b7ad1;
    border-color: transparent; }
    .p-button.p-button-link:enabled:hover .p-button-label {
      text-decoration: underline; }
  .p-button.p-button-link:enabled:focus {
    background: transparent;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa;
    border-color: transparent; }
  .p-button.p-button-link:enabled:active {
    background: transparent;
    color: #0b7ad1;
    border-color: transparent; }

.p-carousel .p-carousel-content .p-carousel-prev,
.p-carousel .p-carousel-content .p-carousel-next {
  width: 2rem;
  height: 2rem;
  color: #6c757d;
  border: 0 none;
  background: transparent;
  border-radius: 50%;
  -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  margin: 0.5rem; }
  .p-carousel .p-carousel-content .p-carousel-prev:enabled:hover,
  .p-carousel .p-carousel-content .p-carousel-next:enabled:hover {
    color: #495057;
    border-color: transparent;
    background: #e9ecef; }
  .p-carousel .p-carousel-content .p-carousel-prev:focus,
  .p-carousel .p-carousel-content .p-carousel-next:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
.p-carousel .p-carousel-indicators {
  padding: 1rem; }
  .p-carousel .p-carousel-indicators .p-carousel-indicator {
    margin-right: 0.5rem;
    margin-bottom: 0.5rem; }
    .p-carousel .p-carousel-indicators .p-carousel-indicator button {
      background-color: #e9ecef;
      width: 2rem;
      height: 0.5rem;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
      border-radius: 0; }
      .p-carousel .p-carousel-indicators .p-carousel-indicator button:hover {
        background: #dee2e6; }
    .p-carousel .p-carousel-indicators .p-carousel-indicator.p-highlight button {
      background: #E3F2FD;
      color: #495057; }

.p-datatable .p-paginator-top {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-datatable .p-paginator-bottom {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-datatable .p-datatable-header {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 1px 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600; }
.p-datatable .p-datatable-footer {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600; }
.p-datatable .p-datatable-thead > tr > th {
  text-align: left;
  padding: 1rem 1rem;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  font-weight: 600;
  color: #495057;
  background: #f8f9fa;
  -webkit-transition: -webkit-box-shadow 0.2s;
  transition: -webkit-box-shadow 0.2s;
  transition: box-shadow 0.2s;
  transition: box-shadow 0.2s, -webkit-box-shadow 0.2s; }
.p-datatable .p-datatable-tfoot > tr > td {
  text-align: left;
  padding: 1rem 1rem;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  font-weight: 600;
  color: #495057;
  background: #f8f9fa; }
.p-datatable .p-sortable-column {
  outline-color: #a6d5fa; }
  .p-datatable .p-sortable-column .p-sortable-column-icon {
    color: #6c757d;
    margin-left: 0.5rem; }
  .p-datatable .p-sortable-column .p-sortable-column-badge {
    border-radius: 50%;
    height: 1.143rem;
    min-width: 1.143rem;
    line-height: 1.143rem;
    color: #495057;
    background: #E3F2FD;
    margin-left: 0.5rem; }
  .p-datatable .p-sortable-column:not(.p-highlight):hover {
    background: #e9ecef;
    color: #495057; }
    .p-datatable .p-sortable-column:not(.p-highlight):hover .p-sortable-column-icon {
      color: #6c757d; }
  .p-datatable .p-sortable-column.p-highlight {
    background: #f8f9fa;
    color: #2196F3; }
    .p-datatable .p-sortable-column.p-highlight .p-sortable-column-icon {
      color: #2196F3; }
.p-datatable .p-datatable-tbody > tr {
  background: #ffffff;
  color: #495057;
  -webkit-transition: -webkit-box-shadow 0.2s;
  transition: -webkit-box-shadow 0.2s;
  transition: box-shadow 0.2s;
  transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
  outline-color: #a6d5fa; }
  .p-datatable .p-datatable-tbody > tr > td {
    text-align: left;
    border: 1px solid #e9ecef;
    border-width: 0 0 1px 0;
    padding: 1rem 1rem; }
    .p-datatable .p-datatable-tbody > tr > td .p-row-toggler,
    .p-datatable .p-datatable-tbody > tr > td .p-row-editor-init,
    .p-datatable .p-datatable-tbody > tr > td .p-row-editor-save,
    .p-datatable .p-datatable-tbody > tr > td .p-row-editor-cancel {
      width: 2rem;
      height: 2rem;
      color: #6c757d;
      border: 0 none;
      background: transparent;
      border-radius: 50%;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
      .p-datatable .p-datatable-tbody > tr > td .p-row-toggler:enabled:hover,
      .p-datatable .p-datatable-tbody > tr > td .p-row-editor-init:enabled:hover,
      .p-datatable .p-datatable-tbody > tr > td .p-row-editor-save:enabled:hover,
      .p-datatable .p-datatable-tbody > tr > td .p-row-editor-cancel:enabled:hover {
        color: #495057;
        border-color: transparent;
        background: #e9ecef; }
      .p-datatable .p-datatable-tbody > tr > td .p-row-toggler:focus,
      .p-datatable .p-datatable-tbody > tr > td .p-row-editor-init:focus,
      .p-datatable .p-datatable-tbody > tr > td .p-row-editor-save:focus,
      .p-datatable .p-datatable-tbody > tr > td .p-row-editor-cancel:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-datatable .p-datatable-tbody > tr > td .p-row-editor-save {
      margin-right: 0.5rem; }
  .p-datatable .p-datatable-tbody > tr.p-highlight {
    background: #E3F2FD;
    color: #495057; }
  .p-datatable .p-datatable-tbody > tr.p-datatable-dragpoint-top > td {
    -webkit-box-shadow: inset 0 2px 0 0 #E3F2FD;
            box-shadow: inset 0 2px 0 0 #E3F2FD; }
  .p-datatable .p-datatable-tbody > tr.p-datatable-dragpoint-bottom > td {
    -webkit-box-shadow: inset 0 -2px 0 0 #E3F2FD;
            box-shadow: inset 0 -2px 0 0 #E3F2FD; }
.p-datatable.p-datatable-hoverable-rows .p-datatable-tbody > tr:not(.p-highlight):hover {
  background: #e9ecef;
  color: #495057; }
.p-datatable .p-column-resizer-helper {
  background: #2196F3; }
.p-datatable .p-datatable-scrollable-header,
.p-datatable .p-datatable-scrollable-footer {
  background: #f8f9fa; }
.p-datatable .p-datatable-loading-icon {
  font-size: 2rem; }
.p-datatable.p-datatable-gridlines .p-datatable-header {
  border-width: 1px 1px 0 1px; }
.p-datatable.p-datatable-gridlines .p-datatable-footer {
  border-width: 0 1px 1px 1px; }
.p-datatable.p-datatable-gridlines .p-paginator-top {
  border-width: 0 1px 0 1px; }
.p-datatable.p-datatable-gridlines .p-paginator-bottom {
  border-width: 0 1px 1px 1px; }
.p-datatable.p-datatable-gridlines .p-datatable-thead > tr > th {
  border-width: 1px 1px 1px 1px; }
.p-datatable.p-datatable-gridlines .p-datatable-tbody > tr > td {
  border-width: 1px; }
.p-datatable.p-datatable-gridlines .p-datatable-tfoot > tr > td {
  border-width: 1px; }
.p-datatable.p-datatable-striped .p-datatable-tbody > tr:nth-child(even) {
  background: #fcfcfc; }
  .p-datatable.p-datatable-striped .p-datatable-tbody > tr:nth-child(even).p-highlight {
    background: #E3F2FD;
    color: #495057; }
    .p-datatable.p-datatable-striped .p-datatable-tbody > tr:nth-child(even).p-highlight .p-row-toggler {
      color: #495057; }
      .p-datatable.p-datatable-striped .p-datatable-tbody > tr:nth-child(even).p-highlight .p-row-toggler:hover {
        color: #495057; }
.p-datatable.p-datatable-sm .p-datatable-header {
  padding: 0.5rem 0.5rem; }
.p-datatable.p-datatable-sm .p-datatable-thead > tr > th {
  padding: 0.5rem 0.5rem; }
.p-datatable.p-datatable-sm .p-datatable-tbody > tr > td {
  padding: 0.5rem 0.5rem; }
.p-datatable.p-datatable-sm .p-datatable-tfoot > tr > td {
  padding: 0.5rem 0.5rem; }
.p-datatable.p-datatable-sm .p-datatable-footer {
  padding: 0.5rem 0.5rem; }
.p-datatable.p-datatable-lg .p-datatable-header {
  padding: 1.25rem 1.25rem; }
.p-datatable.p-datatable-lg .p-datatable-thead > tr > th {
  padding: 1.25rem 1.25rem; }
.p-datatable.p-datatable-lg .p-datatable-tbody > tr > td {
  padding: 1.25rem 1.25rem; }
.p-datatable.p-datatable-lg .p-datatable-tfoot > tr > td {
  padding: 1.25rem 1.25rem; }
.p-datatable.p-datatable-lg .p-datatable-footer {
  padding: 1.25rem 1.25rem; }

.p-dataview .p-paginator-top {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-dataview .p-paginator-bottom {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-dataview .p-dataview-header {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 1px 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600; }
.p-dataview .p-dataview-content {
  background: #ffffff;
  color: #495057;
  border: 0 none;
  padding: 0; }
.p-dataview.p-dataview-list .p-dataview-content > .p-grid > div {
  border: solid #e9ecef;
  border-width: 0 0 1px 0; }
.p-dataview .p-dataview-footer {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600;
  border-bottom-left-radius: 3px;
  border-bottom-right-radius: 3px; }
.p-dataview .p-dataview-loading-icon {
  font-size: 2rem; }

.p-datascroller .p-paginator-top {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-datascroller .p-paginator-bottom {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-datascroller .p-datascroller-header {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 1px 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600; }
.p-datascroller .p-datascroller-content {
  background: #ffffff;
  color: #495057;
  border: 0 none;
  padding: 0; }
.p-datascroller.p-datascroller-inline .p-datascroller-list > li {
  border: solid #e9ecef;
  border-width: 0 0 1px 0; }
.p-datascroller .p-datascroller-footer {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600;
  border-bottom-left-radius: 3px;
  border-bottom-right-radius: 3px; }

.fc .fc-view-container th {
  background: #f8f9fa;
  border: 1px solid #dee2e6;
  color: #495057; }
.fc .fc-view-container td.fc-widget-content {
  background: #ffffff;
  border: 1px solid #dee2e6;
  color: #495057; }
.fc .fc-view-container td.fc-head-container {
  border: 1px solid #dee2e6; }
.fc .fc-view-container .fc-row {
  border-right: 1px solid #dee2e6; }
.fc .fc-view-container .fc-event {
  background: #0d89ec;
  border: 1px solid #0d89ec;
  color: #ffffff; }
.fc .fc-view-container .fc-divider {
  background: #f8f9fa;
  border: 1px solid #dee2e6; }
.fc .fc-toolbar .fc-button {
  color: #ffffff;
  background: #2196F3;
  border: 1px solid #2196F3;
  font-size: 1rem;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  border-radius: 3px;
  display: -ms-flexbox;
  display: flex;
  -ms-flex-align: center;
      align-items: center; }
  .fc .fc-toolbar .fc-button:hover {
    background: #0d89ec;
    color: #ffffff;
    border-color: #0d89ec; }
  .fc .fc-toolbar .fc-button .fc-icon-chevron-left {
    font-family: 'PrimeIcons' !important;
    text-indent: 0;
    font-size: 1rem; }
    .fc .fc-toolbar .fc-button .fc-icon-chevron-left:before {
      content: ""; }
  .fc .fc-toolbar .fc-button .fc-icon-chevron-right {
    font-family: 'PrimeIcons' !important;
    text-indent: 0;
    font-size: 1rem; }
    .fc .fc-toolbar .fc-button .fc-icon-chevron-right:before {
      content: ""; }
  .fc .fc-toolbar .fc-button:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .fc .fc-toolbar .fc-button.fc-dayGridMonth-button, .fc .fc-toolbar .fc-button.fc-timeGridWeek-button, .fc .fc-toolbar .fc-button.fc-timeGridDay-button {
    background: #ffffff;
    border: 1px solid #ced4da;
    color: #495057;
    -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .fc .fc-toolbar .fc-button.fc-dayGridMonth-button:hover, .fc .fc-toolbar .fc-button.fc-timeGridWeek-button:hover, .fc .fc-toolbar .fc-button.fc-timeGridDay-button:hover {
      background: #e9ecef;
      border-color: #ced4da;
      color: #495057; }
    .fc .fc-toolbar .fc-button.fc-dayGridMonth-button.fc-button-active, .fc .fc-toolbar .fc-button.fc-timeGridWeek-button.fc-button-active, .fc .fc-toolbar .fc-button.fc-timeGridDay-button.fc-button-active {
      background: #2196F3;
      border-color: #2196F3;
      color: #ffffff; }
      .fc .fc-toolbar .fc-button.fc-dayGridMonth-button.fc-button-active:hover, .fc .fc-toolbar .fc-button.fc-timeGridWeek-button.fc-button-active:hover, .fc .fc-toolbar .fc-button.fc-timeGridDay-button.fc-button-active:hover {
        background: #0d89ec;
        border-color: #0d89ec;
        color: #ffffff; }
    .fc .fc-toolbar .fc-button.fc-dayGridMonth-button:focus, .fc .fc-toolbar .fc-button.fc-timeGridWeek-button:focus, .fc .fc-toolbar .fc-button.fc-timeGridDay-button:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa;
      z-index: 1; }
.fc .fc-toolbar .fc-button-group .fc-button {
  border-radius: 0; }
  .fc .fc-toolbar .fc-button-group .fc-button:first-child {
    border-top-left-radius: 3px;
    border-bottom-left-radius: 3px; }
  .fc .fc-toolbar .fc-button-group .fc-button:last-child {
    border-top-right-radius: 3px;
    border-bottom-right-radius: 3px; }

.p-orderlist .p-orderlist-controls {
  padding: 1rem; }
  .p-orderlist .p-orderlist-controls .p-button {
    margin-bottom: 0.5rem; }
.p-orderlist .p-orderlist-header {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #dee2e6;
  padding: 1rem;
  font-weight: 600;
  border-bottom: 0 none;
  border-top-right-radius: 3px;
  border-top-left-radius: 3px; }
.p-orderlist .p-orderlist-list {
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  padding: 0.5rem 0;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px; }
  .p-orderlist .p-orderlist-list .p-orderlist-item {
    padding: 0.5rem 1rem;
    margin: 0;
    border: 0 none;
    color: #495057;
    background: transparent;
    -webkit-transition: -webkit-transform 0.2s, -webkit-box-shadow 0.2s;
    transition: -webkit-transform 0.2s, -webkit-box-shadow 0.2s;
    transition: transform 0.2s, box-shadow 0.2s;
    transition: transform 0.2s, box-shadow 0.2s, -webkit-transform 0.2s, -webkit-box-shadow 0.2s; }
    .p-orderlist .p-orderlist-list .p-orderlist-item:not(.p-highlight):hover {
      background: #e9ecef;
      color: #495057; }
    .p-orderlist .p-orderlist-list .p-orderlist-item:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
    .p-orderlist .p-orderlist-list .p-orderlist-item.p-highlight {
      color: #495057;
      background: #E3F2FD; }

@media screen and (max-width: 769px) {
  .p-orderlist {
    -ms-flex-direction: column;
        flex-direction: column; }
    .p-orderlist .p-orderlist-controls {
      padding: 1rem;
      -ms-flex-direction: row;
          flex-direction: row; }
      .p-orderlist .p-orderlist-controls .p-button {
        margin-right: 0.5rem;
        margin-bottom: 0; }
        .p-orderlist .p-orderlist-controls .p-button:last-child {
          margin-right: 0; } }
.p-organizationchart .p-organizationchart-node-content.p-organizationchart-selectable-node:not(.p-highlight):hover {
  background: #e9ecef;
  color: #495057; }
.p-organizationchart .p-organizationchart-node-content.p-highlight {
  background: #E3F2FD;
  color: #495057; }
  .p-organizationchart .p-organizationchart-node-content.p-highlight .p-node-toggler i {
    color: #6cbbf5; }
.p-organizationchart .p-organizationchart-line-down {
  background: #dee2e6; }
.p-organizationchart .p-organizationchart-line-left {
  border-right: 1px solid #dee2e6;
  border-color: #dee2e6; }
.p-organizationchart .p-organizationchart-line-top {
  border-top: 1px solid #dee2e6;
  border-color: #dee2e6; }
.p-organizationchart .p-organizationchart-node-content {
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  padding: 1rem; }
.p-organizationchart .p-organizationchart-node-content .p-node-toggler {
  background: inherit;
  color: inherit;
  border-radius: 50%; }
  .p-organizationchart .p-organizationchart-node-content .p-node-toggler:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }

.p-paginator {
  background: #ffffff;
  color: #6c757d;
  border: solid #e9ecef;
  border-width: 0;
  padding: 0.5rem 1rem;
  border-radius: 3px; }
  .p-paginator .p-paginator-first,
  .p-paginator .p-paginator-prev,
  .p-paginator .p-paginator-next,
  .p-paginator .p-paginator-last {
    background-color: transparent;
    border: 0 none;
    color: #6c757d;
    min-width: 2.357rem;
    height: 2.357rem;
    margin: 0.143rem;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    border-radius: 3px; }
    .p-paginator .p-paginator-first:not(.p-disabled):not(.p-highlight):hover,
    .p-paginator .p-paginator-prev:not(.p-disabled):not(.p-highlight):hover,
    .p-paginator .p-paginator-next:not(.p-disabled):not(.p-highlight):hover,
    .p-paginator .p-paginator-last:not(.p-disabled):not(.p-highlight):hover {
      background: #e9ecef;
      border-color: transparent;
      color: #495057; }
  .p-paginator .p-paginator-first {
    border-top-left-radius: 3px;
    border-bottom-left-radius: 3px; }
  .p-paginator .p-paginator-last {
    border-top-right-radius: 3px;
    border-bottom-right-radius: 3px; }
  .p-paginator .p-dropdown {
    margin-left: 0.5rem;
    height: 2.357rem; }
    .p-paginator .p-dropdown .p-dropdown-label {
      padding-right: 0; }
  .p-paginator .p-paginator-current {
    background-color: transparent;
    border: 0 none;
    color: #6c757d;
    min-width: 2.357rem;
    height: 2.357rem;
    margin: 0.143rem;
    padding: 0 0.5rem; }
  .p-paginator .p-paginator-pages .p-paginator-page {
    background-color: transparent;
    border: 0 none;
    color: #6c757d;
    min-width: 2.357rem;
    height: 2.357rem;
    margin: 0.143rem;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    border-radius: 3px; }
    .p-paginator .p-paginator-pages .p-paginator-page.p-highlight {
      background: #E3F2FD;
      border-color: #E3F2FD;
      color: #495057; }
    .p-paginator .p-paginator-pages .p-paginator-page:not(.p-highlight):hover {
      background: #e9ecef;
      border-color: transparent;
      color: #495057; }

.p-picklist .p-picklist-buttons {
  padding: 1rem; }
  .p-picklist .p-picklist-buttons .p-button {
    margin-bottom: 0.5rem; }
.p-picklist .p-picklist-header {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #dee2e6;
  padding: 1rem;
  font-weight: 600;
  border-bottom: 0 none;
  border-top-right-radius: 3px;
  border-top-left-radius: 3px; }
.p-picklist .p-picklist-list {
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  padding: 0.5rem 0;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px; }
  .p-picklist .p-picklist-list .p-picklist-item {
    padding: 0.5rem 1rem;
    margin: 0;
    border: 0 none;
    color: #495057;
    background: transparent;
    -webkit-transition: -webkit-transform 0.2s, -webkit-box-shadow 0.2s;
    transition: -webkit-transform 0.2s, -webkit-box-shadow 0.2s;
    transition: transform 0.2s, box-shadow 0.2s;
    transition: transform 0.2s, box-shadow 0.2s, -webkit-transform 0.2s, -webkit-box-shadow 0.2s; }
    .p-picklist .p-picklist-list .p-picklist-item:not(.p-highlight):hover {
      background: #e9ecef;
      color: #495057; }
    .p-picklist .p-picklist-list .p-picklist-item:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
    .p-picklist .p-picklist-list .p-picklist-item.p-highlight {
      color: #495057;
      background: #E3F2FD; }

@media screen and (max-width: 769px) {
  .p-picklist {
    -ms-flex-direction: column;
        flex-direction: column; }
    .p-picklist .p-picklist-buttons {
      padding: 1rem;
      -ms-flex-direction: row;
          flex-direction: row; }
      .p-picklist .p-picklist-buttons .p-button {
        margin-right: 0.5rem;
        margin-bottom: 0; }
        .p-picklist .p-picklist-buttons .p-button:last-child {
          margin-right: 0; }
    .p-picklist .p-picklist-transfer-buttons .pi-angle-right:before {
      content: ""; }
    .p-picklist .p-picklist-transfer-buttons .pi-angle-double-right:before {
      content: ""; }
    .p-picklist .p-picklist-transfer-buttons .pi-angle-left:before {
      content: ""; }
    .p-picklist .p-picklist-transfer-buttons .pi-angle-double-left:before {
      content: ""; } }
.p-tree {
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  padding: 1rem;
  border-radius: 3px; }
  .p-tree .p-tree-container .p-treenode {
    padding: 0.143rem; }
    .p-tree .p-tree-container .p-treenode .p-treenode-content {
      border-radius: 3px;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      padding: 0.5rem; }
      .p-tree .p-tree-container .p-treenode .p-treenode-content .p-tree-toggler {
        margin-right: 0.5rem;
        width: 2rem;
        height: 2rem;
        color: #6c757d;
        border: 0 none;
        background: transparent;
        border-radius: 50%;
        -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
        transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
        transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
        transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
        .p-tree .p-tree-container .p-treenode .p-treenode-content .p-tree-toggler:enabled:hover {
          color: #495057;
          border-color: transparent;
          background: #e9ecef; }
        .p-tree .p-tree-container .p-treenode .p-treenode-content .p-tree-toggler:focus {
          outline: 0 none;
          outline-offset: 0;
          -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                  box-shadow: 0 0 0 0.2rem #a6d5fa; }
      .p-tree .p-tree-container .p-treenode .p-treenode-content .p-treenode-icon {
        margin-right: 0.5rem;
        color: #6c757d; }
      .p-tree .p-tree-container .p-treenode .p-treenode-content .p-checkbox {
        margin-right: 0.5rem; }
        .p-tree .p-tree-container .p-treenode .p-treenode-content .p-checkbox .p-indeterminate .p-checkbox-icon {
          color: #495057; }
      .p-tree .p-tree-container .p-treenode .p-treenode-content:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
      .p-tree .p-tree-container .p-treenode .p-treenode-content.p-highlight {
        background: #E3F2FD;
        color: #495057; }
        .p-tree .p-tree-container .p-treenode .p-treenode-content.p-highlight .p-tree-toggler,
        .p-tree .p-tree-container .p-treenode .p-treenode-content.p-highlight .p-treenode-icon {
          color: #495057; }
      .p-tree .p-tree-container .p-treenode .p-treenode-content.p-treenode-selectable:not(.p-highlight):hover {
        background: #e9ecef;
        color: #495057; }
  .p-tree .p-tree-filter-container {
    margin-bottom: 0.5rem; }
    .p-tree .p-tree-filter-container .p-tree-filter {
      width: 100%;
      padding-right: 1.5rem; }
    .p-tree .p-tree-filter-container .p-tree-filter-icon {
      right: 0.5rem;
      color: #6c757d; }
  .p-tree .p-treenode-children {
    padding: 0 0 0 1rem; }
  .p-tree .p-tree-loading-icon {
    font-size: 2rem; }

.p-treetable .p-paginator-top {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-treetable .p-paginator-bottom {
  border-width: 0 0 1px 0;
  border-radius: 0; }
.p-treetable .p-treetable-header {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 1px 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600; }
.p-treetable .p-treetable-footer {
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  padding: 1rem 1rem;
  font-weight: 600; }
.p-treetable .p-treetable-thead > tr > th {
  text-align: left;
  padding: 1rem 1rem;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  font-weight: 600;
  color: #495057;
  background: #f8f9fa;
  -webkit-transition: -webkit-box-shadow 0.2s;
  transition: -webkit-box-shadow 0.2s;
  transition: box-shadow 0.2s;
  transition: box-shadow 0.2s, -webkit-box-shadow 0.2s; }
.p-treetable .p-treetable-tfoot > tr > td {
  text-align: left;
  padding: 1rem 1rem;
  border: 1px solid #e9ecef;
  border-width: 0 0 1px 0;
  font-weight: 600;
  color: #495057;
  background: #f8f9fa; }
.p-treetable .p-sortable-column {
  outline-color: #a6d5fa; }
  .p-treetable .p-sortable-column .p-sortable-column-icon {
    color: #6c757d;
    margin-left: 0.5rem; }
  .p-treetable .p-sortable-column .p-sortable-column-badge {
    border-radius: 50%;
    height: 1.143rem;
    min-width: 1.143rem;
    line-height: 1.143rem;
    color: #495057;
    background: #E3F2FD;
    margin-left: 0.5rem; }
  .p-treetable .p-sortable-column:not(.p-highlight):hover {
    background: #e9ecef;
    color: #495057; }
    .p-treetable .p-sortable-column:not(.p-highlight):hover .p-sortable-column-icon {
      color: #6c757d; }
  .p-treetable .p-sortable-column.p-highlight {
    background: #f8f9fa;
    color: #2196F3; }
    .p-treetable .p-sortable-column.p-highlight .p-sortable-column-icon {
      color: #2196F3; }
.p-treetable .p-treetable-tbody > tr {
  background: #ffffff;
  color: #495057;
  -webkit-transition: -webkit-box-shadow 0.2s;
  transition: -webkit-box-shadow 0.2s;
  transition: box-shadow 0.2s;
  transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
  outline-color: #a6d5fa; }
  .p-treetable .p-treetable-tbody > tr > td {
    text-align: left;
    border: 1px solid #e9ecef;
    border-width: 0 0 1px 0;
    padding: 1rem 1rem; }
    .p-treetable .p-treetable-tbody > tr > td .p-treetable-toggler {
      width: 2rem;
      height: 2rem;
      color: #6c757d;
      border: 0 none;
      background: transparent;
      border-radius: 50%;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
      margin-right: 0.5rem; }
      .p-treetable .p-treetable-tbody > tr > td .p-treetable-toggler:enabled:hover {
        color: #495057;
        border-color: transparent;
        background: #e9ecef; }
      .p-treetable .p-treetable-tbody > tr > td .p-treetable-toggler:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
      .p-treetable .p-treetable-tbody > tr > td .p-treetable-toggler + .p-checkbox {
        margin-right: 0.5rem; }
        .p-treetable .p-treetable-tbody > tr > td .p-treetable-toggler + .p-checkbox .p-indeterminate .p-checkbox-icon {
          color: #495057; }
  .p-treetable .p-treetable-tbody > tr.p-highlight {
    background: #E3F2FD;
    color: #495057; }
    .p-treetable .p-treetable-tbody > tr.p-highlight .p-treetable-toggler {
      color: #495057; }
      .p-treetable .p-treetable-tbody > tr.p-highlight .p-treetable-toggler:hover {
        color: #495057; }
.p-treetable.p-treetable-hoverable-rows .p-treetable-tbody > tr:not(.p-highlight):hover {
  background: #e9ecef;
  color: #495057; }
  .p-treetable.p-treetable-hoverable-rows .p-treetable-tbody > tr:not(.p-highlight):hover .p-treetable-toggler {
    color: #495057; }
.p-treetable .p-column-resizer-helper {
  background: #2196F3; }
.p-treetable .p-treetable-scrollable-header,
.p-treetable .p-treetable-scrollable-footer {
  background: #f8f9fa; }
.p-treetable .p-treetable-loading-icon {
  font-size: 2rem; }
.p-treetable.p-treetable-gridlines .p-datatable-header {
  border-width: 1px 1px 0 1px; }
.p-treetable.p-treetable-gridlines .p-treetable-footer {
  border-width: 0 1px 1px 1px; }
.p-treetable.p-treetable-gridlines .p-treetable-top {
  border-width: 0 1px 0 1px; }
.p-treetable.p-treetable-gridlines .p-treetable-bottom {
  border-width: 0 1px 1px 1px; }
.p-treetable.p-treetable-gridlines .p-treetable-thead > tr > th {
  border-width: 1px; }
.p-treetable.p-treetable-gridlines .p-treetable-tbody > tr > td {
  border-width: 1px; }
.p-treetable.p-treetable-gridlines .p-treetable-tfoot > tr > td {
  border-width: 1px; }
.p-treetable.p-treetable-sm .p-treetable-header {
  padding: 0.875rem 0.875rem; }
.p-treetable.p-treetable-sm .p-treetable-thead > tr > th {
  padding: 0.5rem 0.5rem; }
.p-treetable.p-treetable-sm .p-treetable-tbody > tr > td {
  padding: 0.5rem 0.5rem; }
.p-treetable.p-treetable-sm .p-treetable-tfoot > tr > td {
  padding: 0.5rem 0.5rem; }
.p-treetable.p-treetable-sm .p-treetable-footer {
  padding: 0.5rem 0.5rem; }
.p-treetable.p-treetable-lg .p-treetable-header {
  padding: 1.25rem 1.25rem; }
.p-treetable.p-treetable-lg .p-treetable-thead > tr > th {
  padding: 1.25rem 1.25rem; }
.p-treetable.p-treetable-lg .p-treetable-tbody > tr > td {
  padding: 1.25rem 1.25rem; }
.p-treetable.p-treetable-lg .p-treetable-tfoot > tr > td {
  padding: 1.25rem 1.25rem; }
.p-treetable.p-treetable-lg .p-treetable-footer {
  padding: 1.25rem 1.25rem; }

.p-accordion .p-accordion-header .p-accordion-header-link {
  padding: 1rem;
  border: 1px solid #dee2e6;
  color: #495057;
  background: #f8f9fa;
  font-weight: 600;
  border-radius: 3px;
  -webkit-transition: -webkit-box-shadow 0.2s;
  transition: -webkit-box-shadow 0.2s;
  transition: box-shadow 0.2s;
  transition: box-shadow 0.2s, -webkit-box-shadow 0.2s; }
  .p-accordion .p-accordion-header .p-accordion-header-link .p-accordion-toggle-icon {
    margin-right: 0.5rem; }
.p-accordion .p-accordion-header:not(.p-disabled) .p-accordion-header-link:focus {
  outline: 0 none;
  outline-offset: 0;
  -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
          box-shadow: 0 0 0 0.2rem #a6d5fa; }
.p-accordion .p-accordion-header:not(.p-highlight):not(.p-disabled):hover .p-accordion-header-link {
  background: #e9ecef;
  border-color: #dee2e6;
  color: #495057; }
.p-accordion .p-accordion-header:not(.p-disabled).p-highlight .p-accordion-header-link {
  background: #f8f9fa;
  border-color: #dee2e6;
  color: #495057;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0; }
.p-accordion .p-accordion-header:not(.p-disabled).p-highlight:hover .p-accordion-header-link {
  border-color: #dee2e6;
  background: #e9ecef;
  color: #495057; }
.p-accordion .p-accordion-content {
  padding: 1rem;
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  border-top: 0;
  border-top-right-radius: 0;
  border-top-left-radius: 0;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px; }
.p-accordion .p-accordion-tab {
  margin-bottom: 0; }
  .p-accordion .p-accordion-tab .p-accordion-header .p-accordion-header-link {
    border-radius: 0; }
  .p-accordion .p-accordion-tab:not(:first-child) .p-accordion-header .p-accordion-header-link {
    border-top: 0 none; }
  .p-accordion .p-accordion-tab:not(:first-child) .p-accordion-header:not(.p-highlight):not(.p-disabled):hover .p-accordion-header-link, .p-accordion .p-accordion-tab:not(:first-child) .p-accordion-header:not(.p-disabled).p-highlight:hover .p-accordion-header-link {
    border-top: 0 none; }
  .p-accordion .p-accordion-tab:first-child .p-accordion-header .p-accordion-header-link {
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
  .p-accordion .p-accordion-tab:last-child .p-accordion-header:not(.p-highlight) .p-accordion-header-link {
    border-bottom-right-radius: 3px;
    border-bottom-left-radius: 3px; }

.p-card {
  background: #ffffff;
  color: #495057;
  -webkit-box-shadow: 0 2px 1px -1px rgba(0, 0, 0, 0.2), 0 1px 1px 0 rgba(0, 0, 0, 0.14), 0 1px 3px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 1px -1px rgba(0, 0, 0, 0.2), 0 1px 1px 0 rgba(0, 0, 0, 0.14), 0 1px 3px 0 rgba(0, 0, 0, 0.12);
  border-radius: 3px; }
  .p-card .p-card-body {
    padding: 1rem; }
  .p-card .p-card-title {
    font-size: 1.5rem;
    font-weight: 700;
    margin-bottom: 0.5rem; }
  .p-card .p-card-subtitle {
    font-weight: 400;
    margin-bottom: 0.5rem;
    color: #6c757d; }
  .p-card .p-card-content {
    padding: 1rem 0; }
  .p-card .p-card-footer {
    padding: 1rem 0 0 0; }

.p-fieldset {
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  border-radius: 3px; }
  .p-fieldset .p-fieldset-legend {
    padding: 1rem;
    border: 1px solid #dee2e6;
    color: #495057;
    background: #f8f9fa;
    font-weight: 600;
    border-radius: 3px; }
  .p-fieldset.p-fieldset-toggleable .p-fieldset-legend {
    padding: 0;
    -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-fieldset.p-fieldset-toggleable .p-fieldset-legend a {
      padding: 1rem;
      color: #495057;
      border-radius: 3px;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s; }
      .p-fieldset.p-fieldset-toggleable .p-fieldset-legend a .p-fieldset-toggler {
        margin-right: 0.5rem; }
      .p-fieldset.p-fieldset-toggleable .p-fieldset-legend a:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-fieldset.p-fieldset-toggleable .p-fieldset-legend:hover {
      background: #e9ecef;
      border-color: #dee2e6;
      color: #495057; }
  .p-fieldset .p-fieldset-content {
    padding: 1rem; }

.p-panel .p-panel-header {
  border: 1px solid #dee2e6;
  padding: 1rem;
  background: #f8f9fa;
  color: #495057;
  border-top-right-radius: 3px;
  border-top-left-radius: 3px; }
  .p-panel .p-panel-header .p-panel-title {
    font-weight: 600; }
  .p-panel .p-panel-header .p-panel-header-icon {
    width: 2rem;
    height: 2rem;
    color: #6c757d;
    border: 0 none;
    background: transparent;
    border-radius: 50%;
    -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-panel .p-panel-header .p-panel-header-icon:enabled:hover {
      color: #495057;
      border-color: transparent;
      background: #e9ecef; }
    .p-panel .p-panel-header .p-panel-header-icon:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa; }
.p-panel.p-panel-toggleable .p-panel-header {
  padding: 0.5rem 1rem; }
.p-panel .p-panel-content {
  padding: 1rem;
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px;
  border-top: 0 none; }
.p-panel .p-panel-footer {
  padding: 0.5rem 1rem;
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  border-top: 0 none; }

.p-scrollpanel .p-scrollpanel-bar {
  background: #f8f9fa;
  border: 0 none; }

.p-tabview .p-tabview-nav {
  background: #ffffff;
  border: 1px solid #dee2e6;
  border-width: 0 0 2px 0; }
  .p-tabview .p-tabview-nav li {
    margin-right: 0; }
    .p-tabview .p-tabview-nav li .p-tabview-nav-link {
      border: solid #dee2e6;
      border-width: 0 0 2px 0;
      border-color: transparent transparent #dee2e6 transparent;
      background: #ffffff;
      color: #6c757d;
      padding: 1rem;
      font-weight: 600;
      border-top-right-radius: 3px;
      border-top-left-radius: 3px;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      margin: 0 0 -2px 0; }
      .p-tabview .p-tabview-nav li .p-tabview-nav-link:not(.p-disabled):focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-tabview .p-tabview-nav li:not(.p-highlight):not(.p-disabled):hover .p-tabview-nav-link {
      background: #ffffff;
      border-color: #6c757d;
      color: #6c757d; }
    .p-tabview .p-tabview-nav li.p-highlight .p-tabview-nav-link {
      background: #ffffff;
      border-color: #2196F3;
      color: #2196F3; }
.p-tabview .p-tabview-panels {
  background: #ffffff;
  padding: 1rem;
  border: 0 none;
  color: #495057;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px; }

.p-toolbar {
  background: #f8f9fa;
  border: 1px solid #dee2e6;
  padding: 1rem;
  border-radius: 3px; }
  .p-toolbar .p-toolbar-separator {
    margin: 0 0.5rem; }

.p-dialog {
  border-radius: 3px;
  -webkit-box-shadow: 0px 11px 15px -7px rgba(0, 0, 0, 0.2), 0px 24px 38px 3px rgba(0, 0, 0, 0.14), 0px 9px 46px 8px rgba(0, 0, 0, 0.12);
          box-shadow: 0px 11px 15px -7px rgba(0, 0, 0, 0.2), 0px 24px 38px 3px rgba(0, 0, 0, 0.14), 0px 9px 46px 8px rgba(0, 0, 0, 0.12);
  border: 0 none; }
  .p-dialog .p-dialog-header {
    border-bottom: 0 none;
    background: #ffffff;
    color: #495057;
    padding: 1.5rem;
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
    .p-dialog .p-dialog-header .p-dialog-title {
      font-weight: 600;
      font-size: 1.25rem; }
    .p-dialog .p-dialog-header .p-dialog-header-icon {
      width: 2rem;
      height: 2rem;
      color: #6c757d;
      border: 0 none;
      background: transparent;
      border-radius: 50%;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
      margin-right: 0.5rem; }
      .p-dialog .p-dialog-header .p-dialog-header-icon:enabled:hover {
        color: #495057;
        border-color: transparent;
        background: #e9ecef; }
      .p-dialog .p-dialog-header .p-dialog-header-icon:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
      .p-dialog .p-dialog-header .p-dialog-header-icon:last-child {
        margin-right: 0; }
  .p-dialog .p-dialog-content {
    background: #ffffff;
    color: #495057;
    padding: 0 1.5rem 2rem 1.5rem; }
  .p-dialog .p-dialog-footer {
    border-top: 0 none;
    background: #ffffff;
    color: #495057;
    padding: 0 1.5rem 1.5rem 1.5rem;
    text-align: right;
    border-bottom-right-radius: 3px;
    border-bottom-left-radius: 3px; }
    .p-dialog .p-dialog-footer button {
      margin: 0 0.5rem 0 0;
      width: auto; }

.p-dialog-mask.p-component-overlay {
  background-color: rgba(0, 0, 0, 0.4); }

.p-overlaypanel {
  background: #ffffff;
  color: #495057;
  border: 0 none;
  border-radius: 3px;
  -webkit-box-shadow: 0px 11px 15px -7px rgba(0, 0, 0, 0.2), 0px 24px 38px 3px rgba(0, 0, 0, 0.14), 0px 9px 46px 8px rgba(0, 0, 0, 0.12);
          box-shadow: 0px 11px 15px -7px rgba(0, 0, 0, 0.2), 0px 24px 38px 3px rgba(0, 0, 0, 0.14), 0px 9px 46px 8px rgba(0, 0, 0, 0.12); }
  .p-overlaypanel .p-overlaypanel-content {
    padding: 1rem; }
  .p-overlaypanel .p-overlaypanel-close {
    background: #2196F3;
    color: #ffffff;
    width: 2rem;
    height: 2rem;
    -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
    border-radius: 50%;
    position: absolute;
    top: -1rem;
    right: -1rem; }
    .p-overlaypanel .p-overlaypanel-close:enabled:hover {
      background: #0d89ec;
      color: #ffffff; }
  .p-overlaypanel:after {
    border: solid transparent;
    border-color: rgba(255, 255, 255, 0);
    border-bottom-color: #ffffff; }
  .p-overlaypanel:before {
    border: solid transparent;
    border-color: rgba(255, 255, 255, 0);
    border-bottom-color: #ffffff; }
  .p-overlaypanel.p-overlaypanel-flipped:after {
    border-top-color: #ffffff; }
  .p-overlaypanel.p-overlaypanel-flipped:before {
    border-top-color: #ffffff; }

.p-sidebar {
  background: #ffffff;
  color: #495057;
  padding: 1rem;
  border: 0 none;
  -webkit-box-shadow: 0px 11px 15px -7px rgba(0, 0, 0, 0.2), 0px 24px 38px 3px rgba(0, 0, 0, 0.14), 0px 9px 46px 8px rgba(0, 0, 0, 0.12);
          box-shadow: 0px 11px 15px -7px rgba(0, 0, 0, 0.2), 0px 24px 38px 3px rgba(0, 0, 0, 0.14), 0px 9px 46px 8px rgba(0, 0, 0, 0.12); }
  .p-sidebar .p-sidebar-close,
  .p-sidebar .p-sidebar-icon {
    width: 2rem;
    height: 2rem;
    color: #6c757d;
    border: 0 none;
    background: transparent;
    border-radius: 50%;
    -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-sidebar .p-sidebar-close:enabled:hover,
    .p-sidebar .p-sidebar-icon:enabled:hover {
      color: #495057;
      border-color: transparent;
      background: #e9ecef; }
    .p-sidebar .p-sidebar-close:focus,
    .p-sidebar .p-sidebar-icon:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa; }

.p-sidebar-mask.p-component-overlay {
  background: rgba(0, 0, 0, 0.4); }

.p-tooltip .p-tooltip-text {
  background: #495057;
  color: #ffffff;
  padding: 0.5rem 0.5rem;
  -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
  border-radius: 3px; }
.p-tooltip.p-tooltip-right .p-tooltip-arrow {
  border-right-color: #495057; }
.p-tooltip.p-tooltip-left .p-tooltip-arrow {
  border-left-color: #495057; }
.p-tooltip.p-tooltip-top .p-tooltip-arrow {
  border-top-color: #495057; }
.p-tooltip.p-tooltip-bottom .p-tooltip-arrow {
  border-bottom-color: #495057; }

.p-fileupload .p-fileupload-buttonbar {
  background: #f8f9fa;
  padding: 1rem;
  border: 1px solid #dee2e6;
  color: #495057;
  border-bottom: 0 none;
  border-top-right-radius: 3px;
  border-top-left-radius: 3px; }
  .p-fileupload .p-fileupload-buttonbar .p-button {
    margin-right: 0.5rem; }
    .p-fileupload .p-fileupload-buttonbar .p-button.p-fileupload-choose.p-focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa; }
.p-fileupload .p-fileupload-content {
  background: #ffffff;
  padding: 2rem 1rem;
  border: 1px solid #dee2e6;
  color: #495057;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px; }
.p-fileupload .p-progressbar {
  height: 0.25rem; }
.p-fileupload .p-fileupload-row > div {
  padding: 1rem 1rem; }
.p-fileupload.p-fileupload-advanced .p-message {
  margin-top: 0; }

.p-fileupload-choose:not(.p-disabled):hover {
  background: #0d89ec;
  color: #ffffff;
  border-color: #0d89ec; }
.p-fileupload-choose:not(.p-disabled):active {
  background: #0b7ad1;
  color: #ffffff;
  border-color: #0b7ad1; }

.p-breadcrumb {
  background: #ffffff;
  border: 1px solid #dee2e6;
  border-radius: 3px;
  padding: 1rem; }
  .p-breadcrumb ul li .p-menuitem-link {
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    border-radius: 3px; }
    .p-breadcrumb ul li .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-breadcrumb ul li .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-breadcrumb ul li .p-menuitem-link .p-menuitem-icon {
      color: #6c757d; }
  .p-breadcrumb ul li.p-breadcrumb-chevron {
    margin: 0 0.5rem 0 0.5rem;
    color: #495057; }
  .p-breadcrumb ul li:last-child .p-menuitem-text {
    color: #495057; }
  .p-breadcrumb ul li:last-child .p-menuitem-icon {
    color: #6c757d; }

.p-contextmenu {
  padding: 0.25rem 0;
  background: #ffffff;
  color: #495057;
  border: 0 none;
  -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
          box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
  width: 12.5rem; }
  .p-contextmenu .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 0;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-contextmenu .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-contextmenu .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-contextmenu .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
    .p-contextmenu .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-contextmenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-contextmenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-contextmenu .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-contextmenu .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-contextmenu .p-submenu-list {
    padding: 0.25rem 0;
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-contextmenu .p-menuitem.p-menuitem-active > .p-menuitem-link {
    background: #e9ecef; }
    .p-contextmenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-contextmenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-icon, .p-contextmenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
  .p-contextmenu .p-menu-separator {
    border-top: 1px solid #dee2e6;
    margin: 0.25rem 0; }
  .p-contextmenu .p-submenu-icon {
    font-size: 0.875rem; }

.p-megamenu {
  padding: 0.5rem;
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #dee2e6;
  border-radius: 3px; }
  .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 3px;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link .p-submenu-icon {
      color: #6c757d;
      margin-left: 0.5rem; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem > .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link,
  .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover {
    background: #e9ecef; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-text,
    .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
      color: #495057; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-icon,
    .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
      color: #6c757d; }
    .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link .p-submenu-icon,
    .p-megamenu .p-megamenu-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
      color: #6c757d; }
  .p-megamenu .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 0;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-megamenu .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-megamenu .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-megamenu .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
    .p-megamenu .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-megamenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-megamenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-megamenu .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-megamenu .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-megamenu .p-megamenu-panel {
    background: #ffffff;
    color: #495057;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-megamenu .p-megamenu-submenu-header {
    margin: 0;
    padding: 0.75rem 1rem;
    color: #495057;
    background: #ffffff;
    font-weight: 600;
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
  .p-megamenu .p-megamenu-submenu {
    padding: 0.25rem 0;
    width: 12.5rem; }
    .p-megamenu .p-megamenu-submenu .p-menu-separator {
      border-top: 1px solid #dee2e6;
      margin: 0.25rem 0; }
  .p-megamenu .p-menuitem.p-menuitem-active > .p-menuitem-link {
    background: #e9ecef; }
    .p-megamenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-megamenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-icon, .p-megamenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
  .p-megamenu.p-megamenu-vertical {
    width: 12.5rem;
    padding: 0.25rem 0; }

.p-menu {
  padding: 0.25rem 0;
  background: #ffffff;
  color: #495057;
  border: 1px solid #dee2e6;
  border-radius: 3px;
  width: 12.5rem; }
  .p-menu .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 0;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-menu .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-menu .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-menu .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
    .p-menu .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-menu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-menu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-menu .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-menu .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-menu.p-menu-overlay {
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-menu .p-submenu-header {
    margin: 0;
    padding: 0.75rem 1rem;
    color: #495057;
    background: #ffffff;
    font-weight: 600;
    border-top-right-radius: 0;
    border-top-left-radius: 0; }
  .p-menu .p-menu-separator {
    border-top: 1px solid #dee2e6;
    margin: 0.25rem 0; }

.p-menubar {
  padding: 0.5rem;
  background: #f8f9fa;
  color: #495057;
  border: 1px solid #dee2e6;
  border-radius: 3px; }
  .p-menubar .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 0;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-menubar .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-menubar .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-menubar .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
    .p-menubar .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-menubar .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-menubar .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-menubar .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-menubar .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 3px;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link .p-submenu-icon {
      color: #6c757d;
      margin-left: 0.5rem; }
    .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link,
  .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover {
    background: #e9ecef; }
    .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-text,
    .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
      color: #495057; }
    .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-icon,
    .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
      color: #6c757d; }
    .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link .p-submenu-icon,
    .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
      color: #6c757d; }
  .p-menubar .p-submenu-list {
    padding: 0.25rem 0;
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
    width: 12.5rem; }
    .p-menubar .p-submenu-list .p-menu-separator {
      border-top: 1px solid #dee2e6;
      margin: 0.25rem 0; }
    .p-menubar .p-submenu-list .p-submenu-icon {
      font-size: 0.875rem; }
  .p-menubar .p-menuitem.p-menuitem-active > .p-menuitem-link {
    background: #e9ecef; }
    .p-menubar .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-menubar .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-icon, .p-menubar .p-menuitem.p-menuitem-active > .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }

@media screen and (max-width: 960px) {
  .p-menubar {
    position: relative; }
    .p-menubar .p-menubar-button {
      display: -ms-flexbox;
      display: flex;
      width: 2rem;
      height: 2rem;
      color: #6c757d;
      border-radius: 50%;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
      .p-menubar .p-menubar-button:hover {
        color: #6c757d;
        background: #e9ecef; }
      .p-menubar .p-menubar-button:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-menubar .p-menubar-root-list {
      position: absolute;
      display: none;
      padding: 0.25rem 0;
      background: #ffffff;
      border: 0 none;
      -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
              box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
      width: 100%; }
      .p-menubar .p-menubar-root-list .p-menu-separator {
        border-top: 1px solid #dee2e6;
        margin: 0.25rem 0; }
      .p-menubar .p-menubar-root-list .p-submenu-icon {
        font-size: 0.875rem; }
      .p-menubar .p-menubar-root-list > .p-menuitem {
        width: 100%;
        position: static; }
        .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link {
          padding: 0.75rem 1rem;
          color: #495057;
          border-radius: 0;
          -webkit-transition: -webkit-box-shadow 0.2s;
          transition: -webkit-box-shadow 0.2s;
          transition: box-shadow 0.2s;
          transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
          -webkit-user-select: none;
             -moz-user-select: none;
              -ms-user-select: none;
                  user-select: none; }
          .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link .p-menuitem-text {
            color: #495057; }
          .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link .p-menuitem-icon {
            color: #6c757d;
            margin-right: 0.5rem; }
          .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link .p-submenu-icon {
            color: #6c757d; }
          .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover {
            background: #e9ecef; }
            .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
              color: #495057; }
            .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
              color: #6c757d; }
            .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
              color: #6c757d; }
          .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link:focus {
            outline: 0 none;
            outline-offset: 0;
            -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
                    box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
          .p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link > .p-submenu-icon {
            margin-left: auto;
            -webkit-transition: -webkit-transform 0.2s;
            transition: -webkit-transform 0.2s;
            transition: transform 0.2s;
            transition: transform 0.2s, -webkit-transform 0.2s; }
        .p-menubar .p-menubar-root-list > .p-menuitem.p-menuitem-active > .p-menuitem-link > .p-submenu-icon {
          -webkit-transform: rotate(-180deg);
                  transform: rotate(-180deg); }
      .p-menubar .p-menubar-root-list .p-submenu-list {
        width: 100%;
        position: static;
        -webkit-box-shadow: none;
                box-shadow: none;
        border: 0 none; }
        .p-menubar .p-menubar-root-list .p-submenu-list .p-submenu-icon {
          -webkit-transition: -webkit-transform 0.2s;
          transition: -webkit-transform 0.2s;
          transition: transform 0.2s;
          transition: transform 0.2s, -webkit-transform 0.2s;
          -webkit-transform: rotate(90deg);
                  transform: rotate(90deg); }
        .p-menubar .p-menubar-root-list .p-submenu-list .p-menuitem-active > .p-menuitem-link > .p-submenu-icon {
          -webkit-transform: rotate(-90deg);
                  transform: rotate(-90deg); }
      .p-menubar .p-menubar-root-list .p-menuitem {
        width: 100%;
        position: static; }
      .p-menubar .p-menubar-root-list ul li a {
        padding-left: 2.25rem; }
      .p-menubar .p-menubar-root-list ul li ul li a {
        padding-left: 3.75rem; }
      .p-menubar .p-menubar-root-list ul li ul li ul li a {
        padding-left: 5.25rem; }
      .p-menubar .p-menubar-root-list ul li ul li ul li ul li a {
        padding-left: 6.75rem; }
      .p-menubar .p-menubar-root-list ul li ul li ul li ul li ul li a {
        padding-left: 8.25rem; }
    .p-menubar.p-menubar-mobile-active .p-menubar-root-list {
      display: -ms-flexbox;
      display: flex;
      -ms-flex-direction: column;
          flex-direction: column;
      top: 100%;
      left: 0;
      z-index: 1; } }
.p-panelmenu .p-panelmenu-header > a {
  padding: 1rem;
  border: 1px solid #dee2e6;
  color: #495057;
  background: #f8f9fa;
  font-weight: 600;
  border-radius: 3px;
  -webkit-transition: -webkit-box-shadow 0.2s;
  transition: -webkit-box-shadow 0.2s;
  transition: box-shadow 0.2s;
  transition: box-shadow 0.2s, -webkit-box-shadow 0.2s; }
  .p-panelmenu .p-panelmenu-header > a .p-panelmenu-icon {
    margin-right: 0.5rem; }
  .p-panelmenu .p-panelmenu-header > a .p-menuitem-icon {
    margin-right: 0.5rem; }
  .p-panelmenu .p-panelmenu-header > a:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
.p-panelmenu .p-panelmenu-header:not(.p-highlight):not(.p-disabled) > a:hover {
  background: #e9ecef;
  border-color: #dee2e6;
  color: #495057; }
.p-panelmenu .p-panelmenu-header.p-highlight {
  margin-bottom: 0; }
  .p-panelmenu .p-panelmenu-header.p-highlight > a {
    background: #f8f9fa;
    border-color: #dee2e6;
    color: #495057;
    border-bottom-right-radius: 0;
    border-bottom-left-radius: 0; }
  .p-panelmenu .p-panelmenu-header.p-highlight:not(.p-disabled) > a:hover {
    border-color: #dee2e6;
    background: #e9ecef;
    color: #495057; }
.p-panelmenu .p-panelmenu-content {
  padding: 0.25rem 0;
  border: 1px solid #dee2e6;
  background: #ffffff;
  color: #495057;
  margin-bottom: 0;
  border-top: 0;
  border-top-right-radius: 0;
  border-top-left-radius: 0;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px; }
  .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 0;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
    .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
    .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link .p-panelmenu-icon {
      margin-right: 0.5rem; }
  .p-panelmenu .p-panelmenu-content .p-submenu-list:not(.p-panelmenu-root-submenu) {
    padding: 0 0 0 1rem; }
.p-panelmenu .p-panelmenu-panel {
  margin-bottom: 0; }
  .p-panelmenu .p-panelmenu-panel .p-panelmenu-header > a {
    border-radius: 0; }
  .p-panelmenu .p-panelmenu-panel .p-panelmenu-content {
    border-radius: 0; }
  .p-panelmenu .p-panelmenu-panel:not(:first-child) .p-panelmenu-header > a {
    border-top: 0 none; }
  .p-panelmenu .p-panelmenu-panel:not(:first-child) .p-panelmenu-header:not(.p-highlight):not(.p-disabled):hover > a, .p-panelmenu .p-panelmenu-panel:not(:first-child) .p-panelmenu-header:not(.p-disabled).p-highlight:hover > a {
    border-top: 0 none; }
  .p-panelmenu .p-panelmenu-panel:first-child .p-panelmenu-header > a {
    border-top-right-radius: 3px;
    border-top-left-radius: 3px; }
  .p-panelmenu .p-panelmenu-panel:last-child .p-panelmenu-header:not(.p-highlight) > a {
    border-bottom-right-radius: 3px;
    border-bottom-left-radius: 3px; }
  .p-panelmenu .p-panelmenu-panel:last-child .p-panelmenu-content {
    border-bottom-right-radius: 3px;
    border-bottom-left-radius: 3px; }

.p-slidemenu {
  padding: 0.25rem 0;
  background: #ffffff;
  color: #495057;
  border: 1px solid #dee2e6;
  border-radius: 3px;
  width: 12.5rem; }
  .p-slidemenu .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 0;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-slidemenu .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-slidemenu .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-slidemenu .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
    .p-slidemenu .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-slidemenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-slidemenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-slidemenu .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-slidemenu .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-slidemenu.p-slidemenu-overlay {
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-slidemenu .p-slidemenu-list {
    padding: 0.25rem 0;
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-slidemenu .p-slidemenu.p-slidemenu-active > .p-slidemenu-link {
    background: #e9ecef; }
    .p-slidemenu .p-slidemenu.p-slidemenu-active > .p-slidemenu-link .p-slidemenu-text {
      color: #495057; }
    .p-slidemenu .p-slidemenu.p-slidemenu-active > .p-slidemenu-link .p-slidemenu-icon, .p-slidemenu .p-slidemenu.p-slidemenu-active > .p-slidemenu-link .p-slidemenu-icon {
      color: #6c757d; }
  .p-slidemenu .p-slidemenu-separator {
    border-top: 1px solid #dee2e6;
    margin: 0.25rem 0; }
  .p-slidemenu .p-slidemenu-icon {
    font-size: 0.875rem; }
  .p-slidemenu .p-slidemenu-backward {
    padding: 0.75rem 1rem;
    color: #495057; }

.p-steps .p-steps-item .p-menuitem-link {
  background: transparent;
  -webkit-transition: -webkit-box-shadow 0.2s;
  transition: -webkit-box-shadow 0.2s;
  transition: box-shadow 0.2s;
  transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
  border-radius: 3px;
  background: #ffffff; }
  .p-steps .p-steps-item .p-menuitem-link .p-steps-number {
    color: #495057;
    border: 1px solid #e9ecef;
    background: #ffffff;
    min-width: 2rem;
    height: 2rem;
    line-height: 2rem;
    font-size: 1.143rem;
    z-index: 1;
    border-radius: 50%; }
  .p-steps .p-steps-item .p-menuitem-link .p-steps-title {
    margin-top: 0.5rem;
    color: #6c757d; }
  .p-steps .p-steps-item .p-menuitem-link:not(.p-disabled):focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }
.p-steps .p-steps-item.p-highlight .p-steps-number {
  background: #E3F2FD;
  color: #495057; }
.p-steps .p-steps-item.p-highlight .p-steps-title {
  font-weight: 600;
  color: #495057; }
.p-steps .p-steps-item:before {
  content: ' ';
  border-top: 1px solid #dee2e6;
  width: 100%;
  top: 50%;
  left: 0;
  display: block;
  position: absolute;
  margin-top: -1rem; }

.p-tabmenu .p-tabmenu-nav {
  background: #ffffff;
  border: 1px solid #dee2e6;
  border-width: 0 0 2px 0; }
  .p-tabmenu .p-tabmenu-nav .p-tabmenuitem {
    margin-right: 0; }
    .p-tabmenu .p-tabmenu-nav .p-tabmenuitem .p-menuitem-link {
      border: solid #dee2e6;
      border-width: 0 0 2px 0;
      border-color: transparent transparent #dee2e6 transparent;
      background: #ffffff;
      color: #6c757d;
      padding: 1rem;
      font-weight: 600;
      border-top-right-radius: 3px;
      border-top-left-radius: 3px;
      -webkit-transition: -webkit-box-shadow 0.2s;
      transition: -webkit-box-shadow 0.2s;
      transition: box-shadow 0.2s;
      transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
      margin: 0 0 -2px 0; }
      .p-tabmenu .p-tabmenu-nav .p-tabmenuitem .p-menuitem-link .p-menuitem-icon {
        margin-right: 0.5rem; }
      .p-tabmenu .p-tabmenu-nav .p-tabmenuitem .p-menuitem-link:not(.p-disabled):focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-tabmenu .p-tabmenu-nav .p-tabmenuitem:not(.p-highlight):not(.p-disabled):hover .p-menuitem-link {
      background: #ffffff;
      border-color: #6c757d;
      color: #6c757d; }
    .p-tabmenu .p-tabmenu-nav .p-tabmenuitem.p-highlight .p-menuitem-link {
      background: #ffffff;
      border-color: #2196F3;
      color: #2196F3; }

.p-tieredmenu {
  padding: 0.25rem 0;
  background: #ffffff;
  color: #495057;
  border: 1px solid #dee2e6;
  border-radius: 3px;
  width: 12.5rem; }
  .p-tieredmenu .p-menuitem-link {
    padding: 0.75rem 1rem;
    color: #495057;
    border-radius: 0;
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s;
    -webkit-user-select: none;
       -moz-user-select: none;
        -ms-user-select: none;
            user-select: none; }
    .p-tieredmenu .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-tieredmenu .p-menuitem-link .p-menuitem-icon {
      color: #6c757d;
      margin-right: 0.5rem; }
    .p-tieredmenu .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
    .p-tieredmenu .p-menuitem-link:not(.p-disabled):hover {
      background: #e9ecef; }
      .p-tieredmenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-text {
        color: #495057; }
      .p-tieredmenu .p-menuitem-link:not(.p-disabled):hover .p-menuitem-icon {
        color: #6c757d; }
      .p-tieredmenu .p-menuitem-link:not(.p-disabled):hover .p-submenu-icon {
        color: #6c757d; }
    .p-tieredmenu .p-menuitem-link:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: inset 0 0 0 0.15rem #a6d5fa;
              box-shadow: inset 0 0 0 0.15rem #a6d5fa; }
  .p-tieredmenu.p-tieredmenu-overlay {
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-tieredmenu .p-submenu-list {
    padding: 0.25rem 0;
    background: #ffffff;
    border: 0 none;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12); }
  .p-tieredmenu .p-menuitem.p-menuitem-active > .p-menuitem-link {
    background: #e9ecef; }
    .p-tieredmenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-text {
      color: #495057; }
    .p-tieredmenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-menuitem-icon, .p-tieredmenu .p-menuitem.p-menuitem-active > .p-menuitem-link .p-submenu-icon {
      color: #6c757d; }
  .p-tieredmenu .p-menu-separator {
    border-top: 1px solid #dee2e6;
    margin: 0.25rem 0; }
  .p-tieredmenu .p-submenu-icon {
    font-size: 0.875rem; }

.p-inline-message {
  padding: 0.5rem 0.5rem;
  margin: 0;
  border-radius: 3px; }
  .p-inline-message.p-inline-message-info {
    background: #B3E5FC;
    border: solid #0891cf;
    border-width: 0px;
    color: #044868; }
    .p-inline-message.p-inline-message-info .p-inline-message-icon {
      color: #044868; }
  .p-inline-message.p-inline-message-success {
    background: #C8E6C9;
    border: solid #439446;
    border-width: 0px;
    color: #224a23; }
    .p-inline-message.p-inline-message-success .p-inline-message-icon {
      color: #224a23; }
  .p-inline-message.p-inline-message-warn {
    background: #FFECB3;
    border: solid #d9a300;
    border-width: 0px;
    color: #6d5100; }
    .p-inline-message.p-inline-message-warn .p-inline-message-icon {
      color: #6d5100; }
  .p-inline-message.p-inline-message-error {
    background: #FFCDD2;
    border: solid #e60017;
    border-width: 0px;
    color: #73000c; }
    .p-inline-message.p-inline-message-error .p-inline-message-icon {
      color: #73000c; }
  .p-inline-message .p-inline-message-icon {
    font-size: 1rem;
    margin-right: 0.5rem; }
  .p-inline-message .p-inline-message-text {
    font-size: 1rem; }
  .p-inline-message.p-inline-message-icon-only .p-inline-message-icon {
    margin-right: 0; }

.p-message {
  margin: 1rem 0;
  border-radius: 3px; }
  .p-message .p-message-wrapper {
    padding: 1rem 1.5rem; }
  .p-message .p-message-close {
    width: 2rem;
    height: 2rem;
    border-radius: 50%;
    background: transparent;
    -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-message .p-message-close:hover {
      background: rgba(255, 255, 255, 0.3); }
    .p-message .p-message-close:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa; }
  .p-message.p-message-info {
    background: #B3E5FC;
    border: solid #0891cf;
    border-width: 0 0 0 6px;
    color: #044868; }
    .p-message.p-message-info .p-message-icon {
      color: #044868; }
    .p-message.p-message-info .p-message-close {
      color: #044868; }
  .p-message.p-message-success {
    background: #C8E6C9;
    border: solid #439446;
    border-width: 0 0 0 6px;
    color: #224a23; }
    .p-message.p-message-success .p-message-icon {
      color: #224a23; }
    .p-message.p-message-success .p-message-close {
      color: #224a23; }
  .p-message.p-message-warn {
    background: #FFECB3;
    border: solid #d9a300;
    border-width: 0 0 0 6px;
    color: #6d5100; }
    .p-message.p-message-warn .p-message-icon {
      color: #6d5100; }
    .p-message.p-message-warn .p-message-close {
      color: #6d5100; }
  .p-message.p-message-error {
    background: #FFCDD2;
    border: solid #e60017;
    border-width: 0 0 0 6px;
    color: #73000c; }
    .p-message.p-message-error .p-message-icon {
      color: #73000c; }
    .p-message.p-message-error .p-message-close {
      color: #73000c; }
  .p-message .p-message-text {
    font-size: 1rem;
    font-weight: 500; }
  .p-message .p-message-icon {
    font-size: 1.5rem;
    margin-right: 0.5rem; }

.p-toast {
  opacity: 0.9; }
  .p-toast .p-toast-message {
    margin: 0 0 1rem 0;
    -webkit-box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
    border-radius: 3px; }
    .p-toast .p-toast-message .p-toast-message-content {
      padding: 1rem;
      border-width: 0 0 0 6px; }
      .p-toast .p-toast-message .p-toast-message-content .p-toast-message-text {
        margin: 0 0 0 1rem; }
      .p-toast .p-toast-message .p-toast-message-content .p-toast-message-icon {
        font-size: 2rem; }
      .p-toast .p-toast-message .p-toast-message-content .p-toast-summary {
        font-weight: 700; }
      .p-toast .p-toast-message .p-toast-message-content .p-toast-detail {
        margin: 0.5rem 0 0 0; }
    .p-toast .p-toast-message .p-toast-icon-close {
      width: 2rem;
      height: 2rem;
      border-radius: 50%;
      background: transparent;
      -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
      transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
      .p-toast .p-toast-message .p-toast-icon-close:hover {
        background: rgba(255, 255, 255, 0.3); }
      .p-toast .p-toast-message .p-toast-icon-close:focus {
        outline: 0 none;
        outline-offset: 0;
        -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
                box-shadow: 0 0 0 0.2rem #a6d5fa; }
    .p-toast .p-toast-message.p-toast-message-info {
      background: #B3E5FC;
      border: solid #0891cf;
      border-width: 0 0 0 6px;
      color: #044868; }
      .p-toast .p-toast-message.p-toast-message-info .p-toast-message-icon,
      .p-toast .p-toast-message.p-toast-message-info .p-toast-icon-close {
        color: #044868; }
    .p-toast .p-toast-message.p-toast-message-success {
      background: #C8E6C9;
      border: solid #439446;
      border-width: 0 0 0 6px;
      color: #224a23; }
      .p-toast .p-toast-message.p-toast-message-success .p-toast-message-icon,
      .p-toast .p-toast-message.p-toast-message-success .p-toast-icon-close {
        color: #224a23; }
    .p-toast .p-toast-message.p-toast-message-warn {
      background: #FFECB3;
      border: solid #d9a300;
      border-width: 0 0 0 6px;
      color: #6d5100; }
      .p-toast .p-toast-message.p-toast-message-warn .p-toast-message-icon,
      .p-toast .p-toast-message.p-toast-message-warn .p-toast-icon-close {
        color: #6d5100; }
    .p-toast .p-toast-message.p-toast-message-error {
      background: #FFCDD2;
      border: solid #e60017;
      border-width: 0 0 0 6px;
      color: #73000c; }
      .p-toast .p-toast-message.p-toast-message-error .p-toast-message-icon,
      .p-toast .p-toast-message.p-toast-message-error .p-toast-icon-close {
        color: #73000c; }

.p-galleria .p-galleria-close {
  margin: 0.5rem;
  background: transparent;
  color: #f8f9fa;
  width: 4rem;
  height: 4rem;
  -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  border-radius: 50%; }
  .p-galleria .p-galleria-close .p-galleria-close-icon {
    font-size: 2rem; }
  .p-galleria .p-galleria-close:hover {
    background: rgba(255, 255, 255, 0.1);
    color: #f8f9fa; }
.p-galleria .p-galleria-item-nav {
  background: transparent;
  color: #f8f9fa;
  width: 4rem;
  height: 4rem;
  -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
  border-radius: 3px;
  margin: 0 0.5rem; }
  .p-galleria .p-galleria-item-nav .p-galleria-item-prev-icon,
  .p-galleria .p-galleria-item-nav .p-galleria-item-next-icon {
    font-size: 2rem; }
  .p-galleria .p-galleria-item-nav:not(.p-disabled):hover {
    background: rgba(255, 255, 255, 0.1);
    color: #f8f9fa; }
.p-galleria .p-galleria-caption {
  background: rgba(0, 0, 0, 0.5);
  color: #f8f9fa;
  padding: 1rem; }
.p-galleria .p-galleria-indicators {
  padding: 1rem; }
  .p-galleria .p-galleria-indicators .p-galleria-indicator button {
    background-color: #e9ecef;
    width: 1rem;
    height: 1rem;
    -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
    border-radius: 50%; }
    .p-galleria .p-galleria-indicators .p-galleria-indicator button:hover {
      background: #dee2e6; }
  .p-galleria .p-galleria-indicators .p-galleria-indicator.p-highlight button {
    background: #E3F2FD;
    color: #495057; }
.p-galleria.p-galleria-indicators-bottom .p-galleria-indicator, .p-galleria.p-galleria-indicators-top .p-galleria-indicator {
  margin-right: 0.5rem; }
.p-galleria.p-galleria-indicators-left .p-galleria-indicator, .p-galleria.p-galleria-indicators-right .p-galleria-indicator {
  margin-bottom: 0.5rem; }
.p-galleria.p-galleria-indicator-onitem .p-galleria-indicators {
  background: rgba(0, 0, 0, 0.5); }
  .p-galleria.p-galleria-indicator-onitem .p-galleria-indicators .p-galleria-indicator button {
    background: rgba(255, 255, 255, 0.4); }
    .p-galleria.p-galleria-indicator-onitem .p-galleria-indicators .p-galleria-indicator button:hover {
      background: rgba(255, 255, 255, 0.6); }
  .p-galleria.p-galleria-indicator-onitem .p-galleria-indicators .p-galleria-indicator.p-highlight button {
    background: #E3F2FD;
    color: #495057; }
.p-galleria .p-galleria-thumbnail-container {
  background: rgba(0, 0, 0, 0.9);
  padding: 1rem 0.25rem; }
  .p-galleria .p-galleria-thumbnail-container .p-galleria-thumbnail-prev,
  .p-galleria .p-galleria-thumbnail-container .p-galleria-thumbnail-next {
    margin: 0.5rem;
    background-color: transparent;
    color: #f8f9fa;
    width: 2rem;
    height: 2rem;
    -webkit-transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, -webkit-box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s;
    transition: background-color 0.2s, color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s;
    border-radius: 50%; }
    .p-galleria .p-galleria-thumbnail-container .p-galleria-thumbnail-prev:hover,
    .p-galleria .p-galleria-thumbnail-container .p-galleria-thumbnail-next:hover {
      background: rgba(255, 255, 255, 0.1);
      color: #f8f9fa; }
  .p-galleria .p-galleria-thumbnail-container .p-galleria-thumbnail-item-content {
    -webkit-transition: -webkit-box-shadow 0.2s;
    transition: -webkit-box-shadow 0.2s;
    transition: box-shadow 0.2s;
    transition: box-shadow 0.2s, -webkit-box-shadow 0.2s; }
    .p-galleria .p-galleria-thumbnail-container .p-galleria-thumbnail-item-content:focus {
      outline: 0 none;
      outline-offset: 0;
      -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
              box-shadow: 0 0 0 0.2rem #a6d5fa; }

.p-galleria-mask.p-component-overlay {
  background-color: rgba(0, 0, 0, 0.9); }

.p-inplace .p-inplace-display {
  padding: 0.5rem 0.5rem;
  border-radius: 3px;
  -webkit-transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, -webkit-box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
  transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s, -webkit-box-shadow 0.2s; }
  .p-inplace .p-inplace-display:not(.p-disabled):hover {
    background: #e9ecef;
    color: #495057; }
  .p-inplace .p-inplace-display:focus {
    outline: 0 none;
    outline-offset: 0;
    -webkit-box-shadow: 0 0 0 0.2rem #a6d5fa;
            box-shadow: 0 0 0 0.2rem #a6d5fa; }

.p-progressbar {
  border: 0 none;
  height: 1.5rem;
  background: #dee2e6;
  border-radius: 3px; }
  .p-progressbar .p-progressbar-value {
    border: 0 none;
    margin: 0;
    background: #2196F3; }
  .p-progressbar .p-progressbar-label {
    color: #495057;
    line-height: 1.5rem; }

.p-terminal {
  background: #ffffff;
  color: #495057;
  border: 1px solid #dee2e6;
  padding: 1rem; }
  .p-terminal .p-terminal-input {
    font-size: 1rem;
    font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol"; }

.p-blockui.p-component-overlay {
  background: rgba(0, 0, 0, 0.4); }

.p-badge {
  background: #2196F3;
  color: #ffffff;
  font-size: 0.75rem;
  font-weight: 700;
  min-width: 1.5rem;
  height: 1.5rem;
  line-height: 1.5rem; }
  .p-badge.p-badge-secondary {
    background-color: #607D8B;
    color: #ffffff; }
  .p-badge.p-badge-success {
    background-color: #689F38;
    color: #ffffff; }
  .p-badge.p-badge-info {
    background-color: #0288D1;
    color: #ffffff; }
  .p-badge.p-badge-warning {
    background-color: #FBC02D;
    color: #212529; }
  .p-badge.p-badge-danger {
    background-color: #D32F2F;
    color: #ffffff; }
  .p-badge.p-badge-lg {
    font-size: 1.125rem;
    min-width: 2.25rem;
    height: 2.25rem;
    line-height: 2.25rem; }
  .p-badge.p-badge-xl {
    font-size: 1.5rem;
    min-width: 3rem;
    height: 3rem;
    line-height: 3rem; }

.p-tag {
  background: #2196F3;
  color: #ffffff;
  font-size: 0.75rem;
  font-weight: 700;
  padding: 0.25rem 0.4rem;
  border-radius: 3px; }
  .p-tag.p-tag-success {
    background-color: #689F38;
    color: #ffffff; }
  .p-tag.p-tag-info {
    background-color: #0288D1;
    color: #ffffff; }
  .p-tag.p-tag-warning {
    background-color: #FBC02D;
    color: #212529; }
  .p-tag.p-tag-danger {
    background-color: #D32F2F;
    color: #ffffff; }

/* Customizations to the designer theme should be defined here */
</style>
<style type="text/css">.p-component,.p-component *{-webkit-box-sizing:border-box;box-sizing:border-box}.p-hidden{display:none}.p-hidden-accessible{border:0;clip:rect(0 0 0 0);height:1px;margin:-1px;overflow:hidden;padding:0;position:absolute;width:1px}.p-hidden-accessible input,.p-hidden-accessible select{-webkit-transform:scale(0);transform:scale(0)}.p-reset{margin:0;padding:0;border:0;outline:0;text-decoration:none;font-size:100%;list-style:none}.p-disabled,.p-disabled *{cursor:default !important}.p-component-overlay{position:fixed;top:0;left:0;width:100%;height:100%}.p-overflow-hidden{overflow:hidden}.p-unselectable-text{-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-scrollbar-measure{width:100px;height:100px;overflow:scroll;position:absolute;top:-9999px}@-webkit-keyframes p-fadein{0%{opacity:0}100%{opacity:1}}@keyframes p-fadein{0%{opacity:0}100%{opacity:1}}input[type="button"],input[type="submit"],input[type="reset"],input[type="file"]::-webkit-file-upload-button,button{border-radius:0}.p-link{text-align:left;background-color:transparent;margin:0;padding:0;border:0;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-connected-overlay{opacity:0;-webkit-transform:scaleY(0.8);transform:scaleY(0.8);-webkit-transition:opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1);transition:opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1);transition:transform .12s cubic-bezier(0,0,0.2,1),opacity .12s cubic-bezier(0,0,0.2,1);transition:transform .12s cubic-bezier(0,0,0.2,1),opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1)}.p-connected-overlay-visible{opacity:1;-webkit-transform:scaleY(1);transform:scaleY(1)}.p-connected-overlay-hidden{opacity:0;-webkit-transform:scaleY(1);transform:scaleY(1);-webkit-transition:opacity .1s linear;transition:opacity .1s linear}.p-connected-overlay-enter{opacity:0;-webkit-transform:scaleY(0.8);transform:scaleY(0.8)}.p-connected-overlay-enter-active{opacity:1;-webkit-transform:scaleY(1);transform:scaleY(1);-webkit-transition:opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1);transition:opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1);transition:transform .12s cubic-bezier(0,0,0.2,1),opacity .12s cubic-bezier(0,0,0.2,1);transition:transform .12s cubic-bezier(0,0,0.2,1),opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1)}.p-connected-overlay-enter-done{-webkit-transform:none;transform:none}.p-connected-overlay-exit{opacity:1}.p-connected-overlay-exit-active{opacity:0;-webkit-transition:opacity .1s linear;transition:opacity .1s linear}.p-toggleable-content-enter{max-height:0}.p-toggleable-content-enter-active{overflow:hidden;max-height:1000px;-webkit-transition:max-height 1s ease-in-out;transition:max-height 1s ease-in-out}.p-toggleable-content-enter-done{-webkit-transform:none;transform:none}.p-toggleable-content-exit{max-height:1000px}.p-toggleable-content-exit-active{overflow:hidden;max-height:0;-webkit-transition:max-height .45s cubic-bezier(0,1,0,1);transition:max-height .45s cubic-bezier(0,1,0,1)}.p-sr-only{border:0;clip:rect(1px,1px,1px,1px);-webkit-clip-path:inset(50%);clip-path:inset(50%);height:1px;margin:-1px;overflow:hidden;padding:0;position:absolute;width:1px;word-wrap:normal !important}.p-accordion-header-link{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;position:relative;text-decoration:none}.p-accordion-header-link:focus{z-index:1}.p-accordion-header-text{line-height:1}.p-autocomplete{display:-ms-inline-flexbox;display:inline-flex;position:relative}.p-autocomplete-loader{position:absolute;top:50%;margin-top:-.5rem}.p-autocomplete-dd .p-autocomplete-input{-ms-flex:1 1 auto;flex:1 1 auto;width:1%}.p-autocomplete-dd .p-autocomplete-input,.p-autocomplete-dd .p-autocomplete-multiple-container{border-top-right-radius:0;border-bottom-right-radius:0}.p-autocomplete-dd .p-autocomplete-dropdown{border-top-left-radius:0;border-bottom-left-radius:0}.p-autocomplete .p-autocomplete-panel{min-width:100%}.p-autocomplete-panel{position:absolute;overflow:auto}.p-autocomplete-items{margin:0;padding:0;list-style-type:none}.p-autocomplete-item{cursor:pointer;white-space:nowrap;position:relative;overflow:hidden}.p-autocomplete-multiple-container{margin:0;padding:0;list-style-type:none;cursor:text;overflow:hidden;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-autocomplete-token{cursor:default;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex:0 0 auto;flex:0 0 auto}.p-autocomplete-token-icon{cursor:pointer}.p-autocomplete-input-token{-ms-flex:1 1 auto;flex:1 1 auto;display:-ms-inline-flexbox;display:inline-flex}.p-autocomplete-input-token input{border:0 none;outline:0 none;background-color:transparent;margin:0;padding:0;-webkit-box-shadow:none;box-shadow:none;border-radius:0;width:100%}.p-fluid .p-autocomplete{display:-ms-flexbox;display:flex}.p-fluid .p-autocomplete-dd .p-autocomplete-input{width:1%}.p-badge{display:inline-block;border-radius:50%;text-align:center}.p-tag{display:inline-block;text-align:center;line-height:1.5}.p-tag.p-tag-rounded{border-radius:10rem}.p-overlay-badge{position:relative;display:inline-block}.p-overlay-badge .p-badge{position:absolute;top:0;right:0;-webkit-transform:translate(1em,-1em);transform:translate(1em,-1em);margin:0}.p-breadcrumb ul{margin:0;padding:0;list-style-type:none;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-wrap:wrap;flex-wrap:wrap}.p-breadcrumb .p-menuitem-text{line-height:1}.p-breadcrumb .p-menuitem-link{text-decoration:none}.p-button{margin:0;display:-ms-inline-flexbox;display:inline-flex;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;-ms-flex-align:center;align-items:center;vertical-align:bottom;text-align:center;overflow:hidden;position:relative}.p-button-label{-ms-flex:1 1 auto;flex:1 1 auto}.p-button-icon-right{-ms-flex-order:1;order:1}.p-button:disabled{cursor:default}.p-button-icon-only{-ms-flex-pack:center;justify-content:center}.p-button-icon-only .p-button-label{visibility:hidden;width:0;-ms-flex:0 0 auto;flex:0 0 auto}.p-button-vertical{-ms-flex-direction:column;flex-direction:column}.p-button-icon-bottom{-ms-flex-order:2;order:2}.p-buttonset .p-button{margin:0}.p-buttonset .p-button:not(:last-child){border-right:0 none}.p-buttonset .p-button:not(:first-of-type):not(:last-of-type){border-radius:0}.p-buttonset .p-button:first-of-type{border-top-right-radius:0;border-bottom-right-radius:0}.p-buttonset .p-button:last-of-type{border-top-left-radius:0;border-bottom-left-radius:0}.p-buttonset .p-button:focus{position:relative;z-index:1}.p-calendar{position:relative;display:-ms-inline-flexbox;display:inline-flex}.p-calendar .p-inputtext{-ms-flex:1 1 auto;flex:1 1 auto;width:1%}.p-calendar-w-btn .p-inputtext{border-top-right-radius:0;border-bottom-right-radius:0}.p-calendar-w-btn .p-datepicker-trigger{border-top-left-radius:0;border-bottom-left-radius:0}.p-fluid .p-calendar{display:-ms-flexbox;display:flex}.p-fluid .p-calendar .p-inputtext{width:1%}.p-calendar .p-datepicker{min-width:100%}.p-datepicker{width:auto;position:absolute}.p-datepicker-inline{display:-ms-inline-flexbox;display:inline-flex;position:static}.p-datepicker-header{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:justify;justify-content:space-between}.p-datepicker-header .p-datepicker-title{margin:0 auto}.p-datepicker-prev,.p-datepicker-next{cursor:pointer;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;overflow:hidden;position:relative}.p-datepicker-multiple-month .p-datepicker-group-container{display:-ms-flexbox;display:flex}.p-datepicker table{width:100%;border-collapse:collapse}.p-datepicker td>span{display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;cursor:pointer;margin:0 auto;overflow:hidden;position:relative}.p-monthpicker-month{width:33.3%;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;cursor:pointer;overflow:hidden;position:relative}.p-datepicker-buttonbar{display:-ms-flexbox;display:flex;-ms-flex-pack:justify;justify-content:space-between;-ms-flex-align:center;align-items:center}.p-timepicker{display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center}.p-timepicker button{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;cursor:pointer;overflow:hidden;position:relative}.p-timepicker>div{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-direction:column;flex-direction:column}.p-datepicker-touch-ui,.p-calendar .p-datepicker-touch-ui{position:fixed;top:50%;left:50%;min-width:80vw;-webkit-transform:translate(-50%,-50%);transform:translate(-50%,-50%)}.p-card-header img{width:100%}.p-carousel{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column}.p-carousel-content{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;overflow:auto}.p-carousel-prev,.p-carousel-next{-ms-flex-item-align:center;align-self:center;-ms-flex-positive:0;flex-grow:0;-ms-flex-negative:0;flex-shrink:0;display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;overflow:hidden;position:relative}.p-carousel-container{display:-ms-flexbox;display:flex;-ms-flex-direction:row;flex-direction:row}.p-carousel-items-content{overflow:hidden;width:100%}.p-carousel-items-container{display:-ms-flexbox;display:flex;-ms-flex-direction:row;flex-direction:row}.p-carousel-indicators{display:-ms-flexbox;display:flex;-ms-flex-direction:row;flex-direction:row;-ms-flex-pack:center;justify-content:center;-ms-flex-wrap:wrap;flex-wrap:wrap}.p-carousel-indicator>button{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-carousel-vertical .p-carousel-container{-ms-flex-direction:column;flex-direction:column}.p-carousel-vertical .p-carousel-items-container{-ms-flex-direction:column;flex-direction:column;height:100%}.p-items-hidden .p-carousel-item{visibility:hidden}.p-items-hidden .p-carousel-item.p-carousel-item-active{visibility:visible}.p-chart{position:relative}.p-checkbox{display:-ms-inline-flexbox;display:inline-flex;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;vertical-align:bottom}.p-checkbox-box{display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center}.p-chips{display:-ms-inline-flexbox;display:inline-flex}.p-chips-multiple-container{margin:0;padding:0;list-style-type:none;cursor:text;overflow:hidden;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-chips-token{cursor:default;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex:0 0 auto;flex:0 0 auto}.p-chips-input-token{-ms-flex:1 1 auto;flex:1 1 auto;display:-ms-inline-flexbox;display:inline-flex}.p-chips-token-icon{cursor:pointer}.p-chips-input-token input{border:0 none;outline:0 none;background-color:transparent;margin:0;padding:0;-webkit-box-shadow:none;box-shadow:none;border-radius:0;width:100%}.p-fluid .p-chips{display:-ms-flexbox;display:flex}.p-colorpicker{display:inline-block}.p-colorpicker-dragging{cursor:pointer}.p-colorpicker-overlay{position:relative}.p-colorpicker-panel{position:relative;width:193px;height:166px}.p-colorpicker-overlay-panel{position:absolute}.p-colorpicker-preview{cursor:pointer}.p-colorpicker-panel .p-colorpicker-content{position:relative}.p-colorpicker-panel .p-colorpicker-color-selector{width:150px;height:150px;top:8px;left:8px;position:absolute}.p-colorpicker-panel .p-colorpicker-color{width:150px;height:150px}.p-colorpicker-panel .p-colorpicker-color-handle{position:absolute;top:0;left:150px;border-radius:100%;width:10px;height:10px;border-width:1px;border-style:solid;margin:-5px 0 0 -5px;cursor:pointer;opacity:.85}.p-colorpicker-panel .p-colorpicker-hue{width:17px;height:150px;top:8px;left:167px;position:absolute;opacity:.85}.p-colorpicker-panel .p-colorpicker-hue-handle{position:absolute;top:150px;left:0;width:21px;margin-left:-2px;margin-top:-5px;height:10px;border-width:2px;border-style:solid;opacity:.85;cursor:pointer}.p-colorpicker-panel .p-colorpicker-color{background:transparent url(/static/media/color.c7a33805.png) no-repeat left top}.p-colorpicker-panel .p-colorpicker-hue{background:transparent url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABEAAACWCAIAAAC3uvTNAAAA7ElEQVRYw+2YUQqDQAxEh9GWuqV6Be9/JT88RN0VRUuv0ElBwhKY3yF5m90kLKd+mF/975r6geNyjm9Fy0kgqTJ6nqoIdGKczjmPJU5tZxA8wWPL7YOHKhZAlcmTAVVcxSCrMbfgqY/H6JEOoASPe56tgSrqLR7U2zWojwWjJ3jq47HEiZoGTwJxP1RRXw8y9RZfCMhbhTHOVTxXnUFtPJ5rGjzu35y2KfKGQxWT2K4TQL1d2zz6KAH1kRU8wfOXx+37qY3Hct+aDaqot2u7R/wMuDS3qnj0z0HqK4X/+kRNHdfUwFP2Nisqe/sFuUZiVjC9HCUAAAAASUVORK5CYII=) no-repeat left top}.p-contextmenu{position:absolute}.p-contextmenu ul{margin:0;padding:0;list-style:none}.p-contextmenu .p-submenu-list{position:absolute;min-width:100%;z-index:1}.p-contextmenu .p-menuitem-link{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;text-decoration:none;overflow:hidden;position:relative}.p-contextmenu .p-menuitem-text{line-height:1}.p-contextmenu .p-menuitem{position:relative}.p-contextmenu .p-menuitem-link .p-submenu-icon{margin-left:auto}.p-contextmenu-enter{opacity:0}.p-contextmenu-enter-active{opacity:1;-webkit-transition:opacity 250ms;transition:opacity 250ms}.p-datascroller .p-datascroller-header{text-align:center;padding:.5em .75em;border-bottom:0 none}.p-datascroller .p-datascroller-footer{text-align:center;padding:.25em .625em;border-top:0 none}.p-datascroller .p-datascroller-content{padding:.25em .625em}.p-datascroller-inline .p-datascroller-content{overflow:auto}.p-datascroller .p-datascroller-list{list-style-type:none;margin:0;padding:0}.p-datatable{position:relative}.p-datatable table{border-collapse:collapse;width:100%;table-layout:fixed}.p-datatable .p-sortable-column{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-datatable .p-sortable-column .p-column-title,.p-datatable .p-sortable-column .p-sortable-column-icon,.p-datatable .p-sortable-column .p-sortable-column-badge{vertical-align:middle}.p-datatable .p-sortable-column .p-sortable-column-badge{display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-datatable-auto-layout>.p-datatable-wrapper{overflow-x:auto}.p-datatable-auto-layout>.p-datatable-wrapper>table{table-layout:auto}.p-datatable-hoverable-rows .p-selectable-row{cursor:pointer}.p-datatable-scrollable-wrapper{position:relative}.p-datatable-scrollable-header,.p-datatable-scrollable-footer{overflow:hidden}.p-datatable-scrollable-body{overflow:auto;position:relative}.p-datatable-scrollable-body>table>.p-datatable-tbody>tr:first-child>td{border-top:0 none}.p-datatable-virtual-table{position:absolute}.p-datatable-frozen-view .p-datatable-scrollable-body{overflow:hidden}.p-datatable-frozen-view>.p-datatable-scrollable-body>table>.p-datatable-tbody>tr>td:last-child{border-right:0 none}.p-datatable-unfrozen-view{position:absolute;top:0}.p-datatable-flex-scrollable{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;-ms-flex:1 1;flex:1 1;height:100%}.p-datatable-flex-scrollable .p-datatable-scrollable-wrapper,.p-datatable-flex-scrollable .p-datatable-scrollable-view{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;-ms-flex:1 1;flex:1 1;height:100%}.p-datatable-flex-scrollable .p-datatable-scrollable-body{-ms-flex:1 1;flex:1 1}.p-datatable-resizable>.p-datatable-wrapper{overflow-x:auto}.p-datatable-resizable .p-datatable-thead>tr>th,.p-datatable-resizable .p-datatable-tfoot>tr>td,.p-datatable-resizable .p-datatable-tbody>tr>td{overflow:hidden}.p-datatable-resizable .p-resizable-column{background-clip:padding-box;position:relative}.p-datatable-resizable-fit .p-resizable-column:last-child .p-column-resizer{display:none}.p-datatable .p-column-resizer{display:block;position:absolute !important;top:0;right:0;margin:0;width:.5rem;height:100%;padding:0;cursor:col-resize;border:1px solid transparent}.p-datatable .p-column-resizer-helper{width:1px;position:absolute;z-index:10;display:none}.p-datatable .p-row-editor-init,.p-datatable .p-row-editor-save,.p-datatable .p-row-editor-cancel{display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;overflow:hidden;position:relative}.p-datatable .p-row-toggler{display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;overflow:hidden;position:relative}.p-datatable-reorder-indicator-up,.p-datatable-reorder-indicator-down{position:absolute;display:none}.p-datatable .p-datatable-loading-overlay{position:absolute;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;z-index:1}.p-dataview-loading{position:relative;min-height:4rem}.p-dataview .p-dataview-loading-overlay{position:absolute;z-index:1;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-dialog-mask{position:fixed;top:0;left:0;width:100%;height:100%;display:none;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;pointer-events:none;background-color:transparent;-webkit-transition-property:background-color;transition-property:background-color}.p-dialog-visible{display:-ms-flexbox;display:flex}.p-dialog-mask.p-component-overlay{pointer-events:auto}.p-dialog{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;pointer-events:auto;max-height:90%;-webkit-transform:scale(1);transform:scale(1)}.p-dialog-content{overflow-y:auto}.p-dialog-header{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:justify;justify-content:space-between;-ms-flex-negative:0;flex-shrink:0}.p-dialog-footer{-ms-flex-negative:0;flex-shrink:0}.p-dialog .p-dialog-header-icons{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-dialog .p-dialog-header-icon{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;overflow:hidden;position:relative}.p-fluid .p-dialog-footer .p-button{width:auto}.p-dialog-enter{opacity:0;-webkit-transform:scale(0.7);transform:scale(0.7)}.p-dialog-enter-active{opacity:1;-webkit-transform:scale(1);transform:scale(1);-webkit-transition:all 150ms cubic-bezier(0,0,0.2,1);transition:all 150ms cubic-bezier(0,0,0.2,1)}.p-dialog-enter-done{-webkit-transform:none;transform:none}.p-dialog-exit-active{opacity:0;-webkit-transform:scale(0.7);transform:scale(0.7);-webkit-transition:all 150ms cubic-bezier(0.4,0.0,0.2,1);transition:all 150ms cubic-bezier(0.4,0.0,0.2,1)}.p-dialog-top .p-dialog,.p-dialog-bottom .p-dialog,.p-dialog-left .p-dialog,.p-dialog-right .p-dialog,.p-dialog-top-left .p-dialog,.p-dialog-top-right .p-dialog,.p-dialog-bottom-left .p-dialog,.p-dialog-bottom-right .p-dialog{margin:.75em;-webkit-transition:all .3s ease-out;transition:all .3s ease-out}.p-dialog-top .p-dialog-enter,.p-dialog-top .p-dialog-exit-active{-webkit-transform:translate3d(0,-100%,0);transform:translate3d(0,-100%,0)}.p-dialog-bottom .p-dialog-enter,.p-dialog-bottom .p-dialog-exit-active{-webkit-transform:translate3d(0,100%,0);transform:translate3d(0,100%,0)}.p-dialog-left .p-dialog-enter,.p-dialog-left .p-dialog-exit-active,.p-dialog-top-left .p-dialog-enter,.p-dialog-top-left .p-dialog-exit-active,.p-dialog-bottom-left .p-dialog-enter,.p-dialog-bottom-left .p-dialog-exit-active{-webkit-transform:translate3d(-100%,0,0);transform:translate3d(-100%,0,0)}.p-dialog-right .p-dialog-enter,.p-dialog-right .p-dialog-exit-active,.p-dialog-top-right .p-dialog-enter,.p-dialog-top-right .p-dialog-exit-active,.p-dialog-bottom-right .p-dialog-enter,.p-dialog-bottom-right .p-dialog-exit-active{-webkit-transform:translate3d(100%,0,0);transform:translate3d(100%,0,0)}.p-dialog-top .p-dialog-enter-active,.p-dialog-bottom .p-dialog-enter-active,.p-dialog-left .p-dialog-enter-active,.p-dialog-top-left .p-dialog-enter-active,.p-dialog-bottom-left .p-dialog-enter-active,.p-dialog-right .p-dialog-enter-active,.p-dialog-top-right .p-dialog-enter-active,.p-dialog-bottom-right .p-dialog-enter-active{-webkit-transform:translate3d(0,0,0);transform:translate3d(0,0,0)}.p-dialog-maximized{-webkit-transition:none;transition:none;-webkit-transform:none;transform:none;width:100vw !important;max-height:100%;height:100%}.p-dialog-maximized .p-dialog-content{-ms-flex-positive:1;flex-grow:1}.p-dialog-left{-ms-flex-pack:start;justify-content:flex-start}.p-dialog-right{-ms-flex-pack:end;justify-content:flex-end}.p-dialog-top{-ms-flex-align:start;align-items:flex-start}.p-dialog-top-left{-ms-flex-pack:start;justify-content:flex-start;-ms-flex-align:start;align-items:flex-start}.p-dialog-top-right{-ms-flex-pack:end;justify-content:flex-end;-ms-flex-align:start;align-items:flex-start}.p-dialog-bottom{-ms-flex-align:end;align-items:flex-end}.p-dialog-bottom-left{-ms-flex-pack:start;justify-content:flex-start;-ms-flex-align:end;align-items:flex-end}.p-dialog-bottom-right{-ms-flex-pack:end;justify-content:flex-end;-ms-flex-align:end;align-items:flex-end}.p-dropdown{display:-ms-inline-flexbox;display:inline-flex;cursor:pointer;position:relative;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-dropdown-clear-icon{position:absolute;top:50%;margin-top:-.5rem}.p-dropdown-trigger{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;-ms-flex-negative:0;flex-shrink:0}.p-dropdown-label{display:block;white-space:nowrap;overflow:hidden;-ms-flex:1 1 auto;flex:1 1 auto;width:1%;text-overflow:ellipsis;cursor:pointer}.p-dropdown-label-empty{overflow:hidden;visibility:hidden}input.p-dropdown-label{cursor:default}.p-dropdown .p-dropdown-panel{min-width:100%}.p-dropdown-panel{position:absolute}.p-dropdown-items-wrapper{overflow:auto}.p-dropdown-item{cursor:pointer;font-weight:normal;white-space:nowrap;position:relative;overflow:hidden}.p-dropdown-items{margin:0;padding:0;list-style-type:none}.p-dropdown-filter{width:100%}.p-dropdown-filter-container{position:relative}.p-dropdown-filter-icon{position:absolute;top:50%;margin-top:-.5rem}.p-fluid .p-dropdown{display:-ms-flexbox;display:flex}.p-fluid .p-dropdown .p-dropdown-label{width:1%}.p-fieldset-legend>a,.p-fieldset-legend>span{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-fieldset-toggleable .p-fieldset-legend a{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;overflow:hidden;position:relative;text-decoration:none}.p-fieldset-legend-text{line-height:1}.p-fileupload-content{position:relative}.p-fileupload-row{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-fileupload-row>div{-ms-flex:1 1 auto;flex:1 1 auto;width:25%}.p-fileupload-row>div:last-child{text-align:right}.p-fileupload-content .p-progressbar{width:100%;position:absolute;top:0;left:0}.p-button.p-fileupload-choose{position:relative;overflow:hidden}.p-button.p-fileupload-choose input[type=file]{display:none}.p-fileupload-choose.p-fileupload-choose-selected input[type=file]{display:none}.p-fluid .p-fileupload .p-button{width:auto}.p-galleria-content{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column}.p-galleria-item-wrapper{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;position:relative}.p-galleria-item-container{position:relative;display:-ms-flexbox;display:flex;height:100%}.p-galleria-item-nav{position:absolute;top:50%;margin-top:-.5rem;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;overflow:hidden}.p-galleria-item-prev{left:0;border-top-left-radius:0;border-bottom-left-radius:0}.p-galleria-item-next{right:0;border-top-right-radius:0;border-bottom-right-radius:0}.p-galleria-item{display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;height:100%;width:100%}.p-galleria-item-nav-onhover .p-galleria-item-nav{pointer-events:none;opacity:0;-webkit-transition:opacity .2s ease-in-out;transition:opacity .2s ease-in-out}.p-galleria-item-nav-onhover .p-galleria-item-wrapper:hover .p-galleria-item-nav{pointer-events:all;opacity:1}.p-galleria-item-nav-onhover .p-galleria-item-wrapper:hover .p-galleria-item-nav.p-disabled{pointer-events:none}.p-galleria-caption{position:absolute;bottom:0;left:0;width:100%}.p-galleria-thumbnail-wrapper{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;overflow:auto;-ms-flex-negative:0;flex-shrink:0}.p-galleria-thumbnail-prev,.p-galleria-thumbnail-next{-ms-flex-item-align:center;align-self:center;-ms-flex:0 0 auto;flex:0 0 auto;display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;overflow:hidden;position:relative}.p-galleria-thumbnail-prev span,.p-galleria-thumbnail-next span{display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center}.p-galleria-thumbnail-container{display:-ms-flexbox;display:flex;-ms-flex-direction:row;flex-direction:row}.p-galleria-thumbnail-items-container{overflow:hidden}.p-galleria-thumbnail-items{display:-ms-flexbox;display:flex}.p-galleria-thumbnail-item{overflow:auto;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;cursor:pointer;opacity:.5}.p-galleria-thumbnail-item:hover{opacity:1;-webkit-transition:opacity .3s;transition:opacity .3s}.p-galleria-thumbnail-item-current{opacity:1}.p-galleria-thumbnails-left .p-galleria-content,.p-galleria-thumbnails-right .p-galleria-content{-ms-flex-direction:row;flex-direction:row}.p-galleria-thumbnails-left .p-galleria-item-wrapper,.p-galleria-thumbnails-right .p-galleria-item-wrapper{-ms-flex-direction:row;flex-direction:row}.p-galleria-thumbnails-left .p-galleria-item-wrapper,.p-galleria-thumbnails-top .p-galleria-item-wrapper{-ms-flex-order:2;order:2}.p-galleria-thumbnails-left .p-galleria-thumbnail-wrapper,.p-galleria-thumbnails-top .p-galleria-thumbnail-wrapper{-ms-flex-order:1;order:1}.p-galleria-thumbnails-left .p-galleria-thumbnail-container,.p-galleria-thumbnails-right .p-galleria-thumbnail-container{-ms-flex-direction:column;flex-direction:column;-ms-flex-positive:1;flex-grow:1}.p-galleria-thumbnails-left .p-galleria-thumbnail-items,.p-galleria-thumbnails-right .p-galleria-thumbnail-items{-ms-flex-direction:column;flex-direction:column;height:100%}.p-galleria-indicators{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-galleria-indicator>button{display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center}.p-galleria-indicators-left .p-galleria-item-wrapper,.p-galleria-indicators-right .p-galleria-item-wrapper{-ms-flex-direction:row;flex-direction:row;-ms-flex-align:center;align-items:center}.p-galleria-indicators-left .p-galleria-item-container,.p-galleria-indicators-top .p-galleria-item-container{-ms-flex-order:2;order:2}.p-galleria-indicators-left .p-galleria-indicators,.p-galleria-indicators-top .p-galleria-indicators{-ms-flex-order:1;order:1}.p-galleria-indicators-left .p-galleria-indicators,.p-galleria-indicators-right .p-galleria-indicators{-ms-flex-direction:column;flex-direction:column}.p-galleria-indicator-onitem .p-galleria-indicators{position:absolute;display:-ms-flexbox;display:flex}.p-galleria-indicator-onitem.p-galleria-indicators-top .p-galleria-indicators{top:0;left:0;width:100%;-ms-flex-align:start;align-items:flex-start}.p-galleria-indicator-onitem.p-galleria-indicators-right .p-galleria-indicators{right:0;top:0;height:100%;-ms-flex-align:end;align-items:flex-end}.p-galleria-indicator-onitem.p-galleria-indicators-bottom .p-galleria-indicators{bottom:0;left:0;width:100%;-ms-flex-align:end;align-items:flex-end}.p-galleria-indicator-onitem.p-galleria-indicators-left .p-galleria-indicators{left:0;top:0;height:100%;-ms-flex-align:start;align-items:flex-start}.p-galleria-mask{position:fixed;top:0;left:0;width:100%;height:100%;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;pointer-events:none;background-color:transparent;-webkit-transition-property:background-color;transition-property:background-color}.p-galleria-mask.p-component-overlay{pointer-events:auto}.p-galleria-close{position:absolute;top:0;right:0;display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;overflow:hidden}.p-galleria-mask .p-galleria-item-nav{position:fixed;top:50%;margin-top:-.5rem}.p-galleria-enter{opacity:0;-webkit-transform:scale(0.7);transform:scale(0.7)}.p-galleria-enter-active{opacity:1;-webkit-transform:scale(1);transform:scale(1);-webkit-transition:all 150ms cubic-bezier(0,0,0.2,1);transition:all 150ms cubic-bezier(0,0,0.2,1)}.p-galleria-enter-done{-webkit-transform:none;transform:none}.p-galleria-exit{opacity:1}.p-galleria-exit-active{opacity:0;-webkit-transform:scale(0.7);transform:scale(0.7);-webkit-transition:all 150ms cubic-bezier(0.4,0.0,0.2,1);transition:all 150ms cubic-bezier(0.4,0.0,0.2,1)}.p-galleria-enter-active .p-galleria-item-nav{opacity:0}.p-galleria-mask.p-galleria-mask-leave{background-color:transparent}.p-items-hidden .p-galleria-thumbnail-item{visibility:hidden}.p-items-hidden .p-galleria-thumbnail-item.p-galleria-thumbnail-item-active{visibility:visible}.p-inplace .p-inplace-display{display:inline;cursor:pointer}.p-inplace .p-inplace-content{display:inline}.p-fluid .p-inplace.p-inplace-closable .p-inplace-content{display:-ms-flexbox;display:flex}.p-fluid .p-inplace.p-inplace-closable .p-inplace-content>.p-inputtext{-ms-flex:1 1 auto;flex:1 1 auto;width:1%}.p-inputnumber{display:-ms-inline-flexbox;display:inline-flex}.p-inputnumber-button{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;-ms-flex:0 0 auto;flex:0 0 auto}.p-inputnumber-buttons-stacked .p-button.p-inputnumber-button .p-button-label,.p-inputnumber-buttons-horizontal .p-button.p-inputnumber-button .p-button-label{display:none}.p-inputnumber-buttons-stacked .p-button.p-inputnumber-button-up{border-top-left-radius:0;border-bottom-left-radius:0;border-bottom-right-radius:0;padding:0}.p-inputnumber-buttons-stacked .p-inputnumber-input{border-top-right-radius:0;border-bottom-right-radius:0}.p-inputnumber-buttons-stacked .p-button.p-inputnumber-button-down{border-top-left-radius:0;border-top-right-radius:0;border-bottom-left-radius:0;padding:0}.p-inputnumber-buttons-stacked .p-inputnumber-button-group{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column}.p-inputnumber-buttons-stacked .p-inputnumber-button-group .p-button.p-inputnumber-button{-ms-flex:1 1 auto;flex:1 1 auto}.p-inputnumber-buttons-horizontal .p-button.p-inputnumber-button-up{-ms-flex-order:3;order:3;border-top-left-radius:0;border-bottom-left-radius:0}.p-inputnumber-buttons-horizontal .p-inputnumber-input{-ms-flex-order:2;order:2;border-radius:0}.p-inputnumber-buttons-horizontal .p-button.p-inputnumber-button-down{-ms-flex-order:1;order:1;border-top-right-radius:0;border-bottom-right-radius:0}.p-inputnumber-buttons-vertical{-ms-flex-direction:column;flex-direction:column}.p-inputnumber-buttons-vertical .p-button.p-inputnumber-button-up{-ms-flex-order:1;order:1;border-bottom-left-radius:0;border-bottom-right-radius:0;width:100%}.p-inputnumber-buttons-vertical .p-inputnumber-input{-ms-flex-order:2;order:2;border-radius:0;text-align:center}.p-inputnumber-buttons-vertical .p-button.p-inputnumber-button-down{-ms-flex-order:3;order:3;border-top-left-radius:0;border-top-right-radius:0;width:100%}.p-inputnumber-input{-ms-flex:1 1 auto;flex:1 1 auto}.p-fluid .p-inputnumber{width:100%}.p-fluid .p-inputnumber .p-inputnumber-input{width:1%}.p-fluid .p-inputnumber-buttons-vertical .p-inputnumber-input{width:100%}.p-inputswitch{position:relative;display:inline-block}.p-inputswitch-slider{position:absolute;cursor:pointer;top:0;left:0;right:0;bottom:0}.p-inputswitch-slider:before{position:absolute;content:"";top:50%}.p-inputtext{margin:0}.p-fluid .p-inputtext{width:100%}.p-inputgroup{display:-ms-flexbox;display:flex;-ms-flex-align:stretch;align-items:stretch;width:100%}.p-inputgroup-addon{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-inputgroup .p-float-label{display:-ms-flexbox;display:flex;-ms-flex-align:stretch;align-items:stretch;width:100%}.p-inputgroup .p-inputtext,.p-fluid .p-inputgroup .p-inputtext,.p-inputgroup .p-inputwrapper,.p-fluid .p-inputgroup .p-input{-ms-flex:1 1 auto;flex:1 1 auto;width:1%}.p-float-label{display:block;position:relative}.p-float-label label{position:absolute;pointer-events:none;top:50%;margin-top:-.5rem;-webkit-transition-property:all;transition-property:all;-webkit-transition-timing-function:ease;transition-timing-function:ease;line-height:1}.p-float-label textarea ~ label{top:1rem}.p-float-label input:focus ~ label,.p-float-label input.p-filled ~ label,.p-float-label textarea:focus ~ label,.p-float-label textarea.p-filled ~ label,.p-float-label .p-inputwrapper-focus ~ label,.p-float-label .p-inputwrapper-filled ~ label{top:-.75rem;font-size:12px}.p-float-label .input:-webkit-autofill ~ label{top:-20px;font-size:12px}.p-input-icon-left,.p-input-icon-right{position:relative;display:inline-block}.p-input-icon-left>i,.p-input-icon-right>i{position:absolute;top:50%;margin-top:-.5rem}.p-fluid .p-input-icon-left,.p-fluid .p-input-icon-right{display:block;width:100%}.p-inputtextarea-resizable{overflow:hidden;resize:none}.p-fluid .p-inputtextarea{width:100%}.p-listbox-list-wrapper{overflow:auto}.p-listbox-list{list-style-type:none;margin:0;padding:0}.p-listbox-item{cursor:pointer;position:relative;overflow:hidden}.p-listbox-filter-container{position:relative}.p-listbox-filter-icon{position:absolute;top:50%;margin-top:-.5rem}.p-listbox-filter{width:100%}.p-megamenu-root-list{margin:0;padding:0;list-style:none}.p-megamenu-root-list>.p-menuitem{position:relative}.p-megamenu .p-menuitem-link{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;text-decoration:none;overflow:hidden;position:relative}.p-megamenu .p-menuitem-text{line-height:1}.p-megamenu-panel{display:none;position:absolute;width:auto;z-index:1}.p-megamenu-root-list>.p-menuitem-active>.p-megamenu-panel{display:block}.p-megamenu-submenu{margin:0;padding:0;list-style:none}.p-megamenu-horizontal .p-megamenu-root-list{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-wrap:wrap;flex-wrap:wrap}.p-megamenu-vertical .p-megamenu-root-list{-ms-flex-direction:column;flex-direction:column}.p-megamenu-vertical .p-megamenu-root-list>.p-menuitem-active>.p-megamenu-panel{left:100%;top:0}.p-megamenu-vertical .p-megamenu-root-list>.p-menuitem>.p-menuitem-link>.p-submenu-icon{margin-left:auto}.p-megamenu-grid{display:-ms-flexbox;display:flex}.p-megamenu-col-2,.p-megamenu-col-3,.p-megamenu-col-4,.p-megamenu-col-6,.p-megamenu-col-12{-ms-flex:0 0 auto;flex:0 0 auto;padding:.5rem}.p-megamenu-col-2{width:16.6667%}.p-megamenu-col-3{width:25%}.p-megamenu-col-4{width:33.3333%}.p-megamenu-col-6{width:50%}.p-megamenu-col-12{width:100%}.p-menu-overlay{position:absolute}.p-menu ul{margin:0;padding:0;list-style:none}.p-menu .p-menuitem-link{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;text-decoration:none;overflow:hidden;position:relative}.p-menu .p-menuitem-text{line-height:1}.p-menubar{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-menubar ul{margin:0;padding:0;list-style:none}.p-menubar .p-menuitem-link{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;text-decoration:none;overflow:hidden;position:relative}.p-menubar .p-menuitem-text{line-height:1}.p-menubar .p-menuitem{position:relative}.p-menubar-root-list{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-menubar-root-list>li ul{display:none;z-index:1}.p-menubar-root-list>.p-menuitem-active>.p-submenu-list{display:block}.p-menubar .p-submenu-list{display:none;position:absolute;z-index:1}.p-menubar .p-submenu-list>.p-menuitem-active>.p-submenu-list{display:block;left:100%;top:0}.p-menubar .p-submenu-list .p-menuitem-link .p-submenu-icon{margin-left:auto}.p-menubar .p-menubar-custom,.p-menubar .p-menubar-end{margin-left:auto;-ms-flex-item-align:center;align-self:center}.p-menubar-button{display:none;cursor:pointer;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-inline-message{display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;vertical-align:top}.p-inline-message-icon-only .p-inline-message-text{visibility:hidden;width:0}.p-fluid .p-inline-message{display:-ms-flexbox;display:flex}.p-message-wrapper{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-message-close{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-message-close.p-link{margin-left:auto;overflow:hidden;position:relative}.p-message-enter{opacity:0}.p-message-enter-active{opacity:1;-webkit-transition:opacity .3s;transition:opacity .3s}.p-message-exit{opacity:1;max-height:1000px}.p-message-exit-active{opacity:0;max-height:0;margin:0;overflow:hidden;-webkit-transition:max-height .3s cubic-bezier(0,1,0,1),opacity .3s,margin .3s;transition:max-height .3s cubic-bezier(0,1,0,1),opacity .3s,margin .3s}.p-message-exit-active .p-message-close{display:none}.p-multiselect{display:-ms-inline-flexbox;display:inline-flex;cursor:pointer;position:relative;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-multiselect-trigger{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;-ms-flex-negative:0;flex-shrink:0}.p-multiselect-label-container{overflow:hidden;-ms-flex:1 1 auto;flex:1 1 auto;cursor:pointer}.p-multiselect-label{display:block;white-space:nowrap;cursor:pointer;overflow:hidden;text-overflow:ellipsis}.p-multiselect-label-empty{overflow:hidden;visibility:hidden}.p-multiselect .p-multiselect-panel{min-width:100%}.p-multiselect-panel{position:absolute}.p-multiselect-items-wrapper{overflow:auto}.p-multiselect-items{margin:0;padding:0;list-style-type:none}.p-multiselect-item{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;font-weight:normal;white-space:nowrap;position:relative;overflow:hidden}.p-multiselect-header{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:justify;justify-content:space-between}.p-multiselect-filter-container{position:relative;-ms-flex:1 1 auto;flex:1 1 auto}.p-multiselect-filter-icon{position:absolute;top:50%;margin-top:-.5rem}.p-multiselect-filter-container .p-inputtext{width:100%}.p-multiselect-close{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;-ms-flex-negative:0;flex-shrink:0;overflow:hidden;position:relative}.p-fluid .p-multiselect{display:-ms-flexbox;display:flex}.p-orderlist{display:-ms-flexbox;display:flex}.p-orderlist-controls{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;-ms-flex-pack:center;justify-content:center}.p-orderlist-list-container{-ms-flex:1 1 auto;flex:1 1 auto}.p-orderlist-list{list-style-type:none;margin:0;padding:0;overflow:auto;min-height:12rem;max-height:24rem}.p-orderlist-item{cursor:pointer;overflow:hidden;position:relative}.p-orderlist.p-state-disabled .p-orderlist-item,.p-orderlist.p-state-disabled .p-button{cursor:default}.p-orderlist.p-state-disabled .p-orderlist-list{overflow:hidden}.p-organizationchart-table{border-spacing:0;border-collapse:separate;margin:0 auto}.p-organizationchart-table>tbody>tr>td{text-align:center;vertical-align:top;padding:0 .75rem}.p-organizationchart-node-content{display:inline-block;position:relative}.p-organizationchart-node-content .p-node-toggler{position:absolute;bottom:-.75rem;margin-left:-.75rem;z-index:2;left:50%;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;cursor:pointer;width:1.5rem;height:1.5rem}.p-organizationchart-node-content .p-node-toggler .p-node-toggler-icon{position:relative;top:.25rem}.p-organizationchart-line-down{margin:0 auto;height:20px;width:1px}.p-organizationchart-line-right{border-radius:0}.p-organizationchart-line-left{border-radius:0}.p-organizationchart-selectable-node{cursor:pointer}.p-overlaypanel{position:absolute;margin-top:10px}.p-overlaypanel-flipped{margin-top:0;margin-bottom:10px}.p-overlaypanel-close{display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;overflow:hidden;position:relative}.p-overlaypanel-enter{opacity:0;-webkit-transform:scaleY(0.8);transform:scaleY(0.8)}.p-overlaypanel-enter-active{opacity:1;-webkit-transform:scaleY(1);transform:scaleY(1);-webkit-transition:opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1);transition:opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1);transition:transform .12s cubic-bezier(0,0,0.2,1),opacity .12s cubic-bezier(0,0,0.2,1);transition:transform .12s cubic-bezier(0,0,0.2,1),opacity .12s cubic-bezier(0,0,0.2,1),-webkit-transform .12s cubic-bezier(0,0,0.2,1)}.p-overlaypanel-enter-done{-webkit-transform:none;transform:none}.p-overlaypanel-exit{opacity:1}.p-overlaypanel-exit-active{opacity:0;-webkit-transition:opacity .1s linear;transition:opacity .1s linear}.p-overlaypanel:after,.p-overlaypanel:before{bottom:100%;left:1.25rem;content:" ";height:0;width:0;position:absolute;pointer-events:none}.p-overlaypanel:after{border-width:8px;margin-left:-8px}.p-overlaypanel:before{border-width:10px;margin-left:-10px}.p-overlaypanel-flipped:after,.p-overlaypanel-flipped:before{bottom:auto;top:100%}.p-overlaypanel.p-overlaypanel-flipped:after{border-bottom-color:transparent}.p-overlaypanel.p-overlaypanel-flipped:before{border-bottom-color:transparent}.p-paginator{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;-ms-flex-wrap:wrap;flex-wrap:wrap}.p-paginator-left-content{margin-right:auto}.p-paginator-right-content{margin-left:auto}.p-paginator-page,.p-paginator-next,.p-paginator-last,.p-paginator-first,.p-paginator-prev,.p-paginator-current{cursor:pointer;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;line-height:1;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;overflow:hidden;position:relative}.p-paginator-element:focus{z-index:1;position:relative}.p-panel-header{display:-ms-flexbox;display:flex;-ms-flex-pack:justify;justify-content:space-between;-ms-flex-align:center;align-items:center}.p-panel-title{line-height:1}.p-panel-header-icon{display:-ms-inline-flexbox;display:inline-flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center;cursor:pointer;text-decoration:none;overflow:hidden;position:relative}.p-panelmenu .p-panelmenu-header-link{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;cursor:pointer;position:relative;text-decoration:none}.p-panelmenu .p-panelmenu-header-link:focus{z-index:1}.p-panelmenu .p-submenu-list{margin:0;padding:0;list-style:none}.p-panelmenu .p-menuitem-link{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;cursor:pointer;text-decoration:none}.p-panelmenu .p-menuitem-text{line-height:1}.p-password-panel{position:absolute}.p-password-meter{background:transparent url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAJYAAAAoAgMAAABhr+t0AAAADFBMVEXx8fHjHD39uB5KpWRhxht7AAAAJUlEQVR4AWMYDGAUhCKBgAFSNqpsFS5AR2Wjyv4TAz7QVNmoMgB5UksJhzldcwAAAABJRU5ErkJggg==) no-repeat left top;height:10px}.p-picklist{display:-ms-flexbox;display:flex}.p-picklist-buttons{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column;-ms-flex-pack:center;justify-content:center}.p-picklist-list-wrapper{-ms-flex:1 1 50%;flex:1 1 50%}.p-picklist-list{list-style-type:none;margin:0;padding:0;overflow:auto;min-height:12rem;max-height:24rem}.p-picklist-item{cursor:pointer;overflow:hidden;position:relative}.p-progressbar{position:relative;overflow:hidden}.p-progressbar-determinate .p-progressbar-value{height:100%;width:0;position:absolute;display:none;border:0 none}.p-progressbar-determinate .p-progressbar-value-animate{-webkit-transition:width 1s ease-in-out;transition:width 1s ease-in-out}.p-progressbar-determinate .p-progressbar-label{text-align:center;height:100%;width:100%;position:absolute;font-weight:bold}.p-progressbar-indeterminate .p-progressbar-value::before{content:'';position:absolute;background-color:inherit;top:0;left:0;bottom:0;will-change:left,right;-webkit-animation:p-progressbar-indeterminate-anim 2.1s cubic-bezier(0.65,0.815,0.735,0.395) infinite;animation:p-progressbar-indeterminate-anim 2.1s cubic-bezier(0.65,0.815,0.735,0.395) infinite}.p-progressbar-indeterminate .p-progressbar-value::after{content:'';position:absolute;background-color:inherit;top:0;left:0;bottom:0;will-change:left,right;-webkit-animation:p-progressbar-indeterminate-anim-short 2.1s cubic-bezier(0.165,0.84,0.44,1) infinite;animation:p-progressbar-indeterminate-anim-short 2.1s cubic-bezier(0.165,0.84,0.44,1) infinite;-webkit-animation-delay:1.15s;animation-delay:1.15s}@-webkit-keyframes p-progressbar-indeterminate-anim{0%{left:-35%;right:100%}60%{left:100%;right:-90%}100%{left:100%;right:-90%}}@keyframes p-progressbar-indeterminate-anim{0%{left:-35%;right:100%}60%{left:100%;right:-90%}100%{left:100%;right:-90%}}@-webkit-keyframes p-progressbar-indeterminate-anim-short{0%{left:-200%;right:100%}60%{left:107%;right:-8%}100%{left:107%;right:-8%}}@keyframes p-progressbar-indeterminate-anim-short{0%{left:-200%;right:100%}60%{left:107%;right:-8%}100%{left:107%;right:-8%}}.p-progress-spinner{position:relative;margin:0 auto;width:100px;height:100px;display:inline-block}.p-progress-spinner::before{content:'';display:block;padding-top:100%}.p-progress-spinner-svg{-webkit-animation:p-progress-spinner-rotate 2s linear infinite;animation:p-progress-spinner-rotate 2s linear infinite;height:100%;-webkit-transform-origin:center center;transform-origin:center center;width:100%;position:absolute;top:0;bottom:0;left:0;right:0;margin:auto}.p-progress-spinner-circle{stroke-dasharray:89,200;stroke-dashoffset:0;stroke:#d62d20;-webkit-animation:p-progress-spinner-dash 1.5s ease-in-out infinite,p-progress-spinner-color 6s ease-in-out infinite;animation:p-progress-spinner-dash 1.5s ease-in-out infinite,p-progress-spinner-color 6s ease-in-out infinite;stroke-linecap:round}@-webkit-keyframes p-progress-spinner-rotate{100%{-webkit-transform:rotate(360deg);transform:rotate(360deg)}}@keyframes p-progress-spinner-rotate{100%{-webkit-transform:rotate(360deg);transform:rotate(360deg)}}@-webkit-keyframes p-progress-spinner-dash{0%{stroke-dasharray:1,200;stroke-dashoffset:0}50%{stroke-dasharray:89,200;stroke-dashoffset:-35px}100%{stroke-dasharray:89,200;stroke-dashoffset:-124px}}@keyframes p-progress-spinner-dash{0%{stroke-dasharray:1,200;stroke-dashoffset:0}50%{stroke-dasharray:89,200;stroke-dashoffset:-35px}100%{stroke-dasharray:89,200;stroke-dashoffset:-124px}}@-webkit-keyframes p-progress-spinner-color{100%,0%{stroke:#d62d20}40%{stroke:#0057e7}66%{stroke:#008744}80%,90%{stroke:#ffa700}}@keyframes p-progress-spinner-color{100%,0%{stroke:#d62d20}40%{stroke:#0057e7}66%{stroke:#008744}80%,90%{stroke:#ffa700}}.p-radiobutton{display:-ms-inline-flexbox;display:inline-flex;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;vertical-align:bottom}.p-radiobutton-box{display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex-align:center;align-items:center}.p-radiobutton-icon{-webkit-backface-visibility:hidden;backface-visibility:hidden;-webkit-transform:translateZ(0) scale(.1);transform:translateZ(0) scale(.1);border-radius:50%;visibility:hidden}.p-radiobutton-box.p-highlight .p-radiobutton-icon{-webkit-transform:translateZ(0) scale(1.0,1.0);transform:translateZ(0) scale(1.0,1.0);visibility:visible}.p-rating-icon{cursor:pointer}.p-rating.p-rating-readonly .p-rating-icon{cursor:default}.p-ripple{overflow:hidden;position:relative}.p-ink{display:block;position:absolute;background:rgba(255,255,255,0.5);border-radius:100%;-webkit-transform:scale(0);transform:scale(0)}.p-ink-active{-webkit-animation:ripple .4s linear;animation:ripple .4s linear}.p-ripple-disabled .p-ink{display:none !important}@-webkit-keyframes ripple{100%{opacity:0;-webkit-transform:scale(2.5);transform:scale(2.5)}}@keyframes ripple{100%{opacity:0;-webkit-transform:scale(2.5);transform:scale(2.5)}}.p-scrollpanel-wrapper{overflow:hidden;width:100%;height:100%;position:relative;z-index:1;float:left}.p-scrollpanel-content{height:calc(100% + 18px);width:calc(100% + 18px);padding:0 18px 18px 0;position:relative;overflow:auto;-webkit-box-sizing:border-box;box-sizing:border-box}.p-scrollpanel-bar{position:relative;background:#c1c1c1;border-radius:3px;z-index:2;cursor:pointer;opacity:0;-webkit-transition:opacity .25s linear;transition:opacity .25s linear}.p-scrollpanel-bar-y{width:9px;top:0}.p-scrollpanel-bar-x{height:9px;bottom:0}.p-scrollpanel-hidden{visibility:hidden}.p-scrollpanel:hover .p-scrollpanel-bar,.p-scrollpanel:active .p-scrollpanel-bar{opacity:1}.p-scrollpanel-grabbed{-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-sidebar{position:fixed}.p-sidebar-content{position:relative}.p-sidebar-icons{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:end;justify-content:flex-end}.p-sidebar-icon{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-sidebar-mask{background-color:transparent;-webkit-transition-property:background-color;transition-property:background-color}.p-sidebar-mask-leave.p-component-overlay{background-color:transparent}.p-sidebar-left{top:0;left:0;width:20rem;height:100%}.p-sidebar-right{top:0;right:0;width:20rem;height:100%}.p-sidebar-top{top:0;left:0;width:100%;height:10rem}.p-sidebar-bottom{bottom:0;left:0;width:100%;height:10rem}.p-sidebar-full{width:100%;height:100%;top:0;left:0;-webkit-transition:none;transition:none}.p-sidebar-left.p-sidebar-enter{-webkit-transform:translateX(-100%);transform:translateX(-100%)}.p-sidebar-left.p-sidebar-enter-active{-webkit-transform:translateX(0);transform:translateX(0);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-left.p-sidebar-exit{-webkit-transform:translateX(0);transform:translateX(0)}.p-sidebar-left.p-sidebar-exit-active{-webkit-transform:translateX(-100%);transform:translateX(-100%);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-right.p-sidebar-enter{-webkit-transform:translateX(100%);transform:translateX(100%)}.p-sidebar-right.p-sidebar-enter-active{-webkit-transform:translateX(0);transform:translateX(0);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-right.p-sidebar-exit{-webkit-transform:translateX(0);transform:translateX(0)}.p-sidebar-right.p-sidebar-exit-active{-webkit-transform:translateX(100%);transform:translateX(100%);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-top.p-sidebar-enter{-webkit-transform:translateY(-100%);transform:translateY(-100%)}.p-sidebar-top.p-sidebar-enter-active{-webkit-transform:translateY(0);transform:translateY(0);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-top.p-sidebar-exit{-webkit-transform:translateY(0);transform:translateY(0)}.p-sidebar-top.p-sidebar-exit-active{-webkit-transform:translateY(-100%);transform:translateY(-100%);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-bottom.p-sidebar-enter{-webkit-transform:translateY(100%);transform:translateY(100%)}.p-sidebar-bottom.p-sidebar-enter-active{-webkit-transform:translateY(0);transform:translateY(0);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-bottom.p-sidebar-exit{-webkit-transform:translateY(0);transform:translateY(0)}.p-sidebar-bottom.p-sidebar-exit-active{-webkit-transform:translateY(100%);transform:translateY(100%);-webkit-transition:-webkit-transform .3s;transition:-webkit-transform .3s;transition:transform .3s;transition:transform .3s, -webkit-transform .3s}.p-sidebar-full.p-sidebar-enter{opacity:0}.p-sidebar-full.p-sidebar-enter-active{opacity:1;-webkit-transition:opacity 400ms cubic-bezier(0.25,0.8,0.25,1);transition:opacity 400ms cubic-bezier(0.25,0.8,0.25,1)}.p-sidebar-full.p-sidebar-exit{opacity:1}.p-sidebar-full.p-sidebar-exit-active{opacity:0;-webkit-transition:opacity 400ms cubic-bezier(0.25,0.8,0.25,1);transition:opacity 400ms cubic-bezier(0.25,0.8,0.25,1)}.p-sidebar-left.p-sidebar-sm,.p-sidebar-right.p-sidebar-sm{width:20rem}.p-sidebar-left.p-sidebar-md,.p-sidebar-right.p-sidebar-md{width:40rem}.p-sidebar-left.p-sidebar-lg,.p-sidebar-right.p-sidebar-lg{width:60rem}.p-sidebar-top.p-sidebar-sm,.p-sidebar-bottom.p-sidebar-sm{height:10rem}.p-sidebar-top.p-sidebar-md,.p-sidebar-bottom.p-sidebar-md{height:20rem}.p-sidebar-top.p-sidebar-lg,.p-sidebar-bottom.p-sidebar-lg{height:30rem}@media screen and (max-width:64em){.p-sidebar-left.p-sidebar-lg,.p-sidebar-left.p-sidebar-md,.p-sidebar-right.p-sidebar-lg,.p-sidebar-right.p-sidebar-md{width:20rem}}.p-slidemenu{width:12.5em}.p-slidemenu.p-slidemenu-overlay{position:absolute}.p-slidemenu .p-menu-separator{border-width:1px 0 0 0}.p-slidemenu ul{list-style:none;margin:0;padding:0}.p-slidemenu .p-slidemenu-rootlist{position:absolute;top:0}.p-slidemenu .p-submenu-list{display:none;position:absolute;top:0;width:12.5em}.p-slidemenu .p-menuitem-link{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;text-decoration:none;overflow:hidden}.p-slidemenu .p-menuitem-icon{vertical-align:middle}.p-slidemenu .p-menuitem-text{vertical-align:middle}.p-slidemenu .p-menuitem{position:relative}.p-slidemenu .p-menuitem-link .p-submenu-icon{margin-left:auto}.p-slidemenu .p-slidemenu-wrapper{position:relative}.p-slidemenu .p-slidemenu-content{overflow-x:hidden;overflow-y:auto;position:relative;height:100%}.p-slidemenu-backward{position:absolute;bottom:0;width:100%;padding:.25em;cursor:pointer}.p-slidemenu-backward .p-slidemenu-backward-icon{vertical-align:middle}.p-slidemenu-backward span{vertical-align:middle}.p-slidemenu .p-menuitem-active{position:static}.p-slidemenu .p-menuitem-active>.p-submenu-list{display:block}.p-slider{position:relative}.p-slider .p-slider-handle{position:absolute;cursor:-webkit-grab;cursor:grab;-ms-touch-action:none;touch-action:none;display:block;z-index:1}.p-slider .p-slider-handle.p-slider-handle-active{z-index:2}.p-slider-range{position:absolute;display:block}.p-slider-horizontal .p-slider-range{top:0;left:0;height:100%}.p-slider-horizontal .p-slider-handle{top:50%}.p-slider-vertical{height:100px}.p-slider-vertical .p-slider-handle{left:50%}.p-slider-vertical .p-slider-range{bottom:0;left:0;width:100%}.p-splitbutton{display:-ms-inline-flexbox;display:inline-flex;position:relative}.p-splitbutton .p-splitbutton-defaultbutton{-ms-flex:1 1 auto;flex:1 1 auto;border-top-right-radius:0;border-bottom-right-radius:0;border-right:0 none}.p-splitbutton-menubutton{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;border-top-left-radius:0;border-bottom-left-radius:0}.p-splitbutton .p-menu{min-width:100%}.p-fluid .p-splitbutton{display:-ms-flexbox;display:flex}.p-steps{position:relative}.p-steps ul{padding:0;margin:0;list-style-type:none;display:-ms-flexbox;display:flex}.p-steps-item{position:relative;display:-ms-flexbox;display:flex;-ms-flex-pack:center;justify-content:center;-ms-flex:1 1 auto;flex:1 1 auto}.p-steps-item .p-menuitem-link{display:-ms-inline-flexbox;display:inline-flex;-ms-flex-direction:column;flex-direction:column;-ms-flex-align:center;align-items:center;overflow:hidden;text-decoration:none}.p-steps.p-steps-readonly .p-steps-item{cursor:auto}.p-steps-item.p-steps-current .p-menuitem-link{cursor:default}.p-steps-title{white-space:nowrap}.p-steps-number{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-steps-title{display:block}.p-tabmenu-nav{display:-ms-flexbox;display:flex;margin:0;padding:0;list-style-type:none;-ms-flex-wrap:wrap;flex-wrap:wrap}.p-tabmenu-nav a{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;position:relative;text-decoration:none;text-decoration:none;overflow:hidden}.p-tabmenu-nav a:focus{z-index:1}.p-tabmenu-nav .p-menuitem-text{line-height:1}.p-tabmenu-ink-bar{display:none;z-index:1}.p-tabview-nav{display:-ms-flexbox;display:flex;margin:0;padding:0;list-style-type:none;-ms-flex-wrap:wrap;flex-wrap:wrap}.p-tabview-nav-link{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;position:relative;text-decoration:none;overflow:hidden}.p-tabview-ink-bar{display:none;z-index:1}.p-tabview-nav-link:focus{z-index:1}.p-tabview-title{line-height:1}.p-tieredmenu-overlay{position:absolute}.p-tieredmenu ul{margin:0;padding:0;list-style:none}.p-tieredmenu .p-submenu-list{position:absolute;min-width:100%;z-index:1;display:none}.p-tieredmenu .p-menuitem-link{cursor:pointer;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;text-decoration:none;overflow:hidden;position:relative}.p-tieredmenu .p-menuitem-text{line-height:1}.p-tieredmenu .p-menuitem{position:relative}.p-tieredmenu .p-menuitem-link .p-submenu-icon{margin-left:auto}.p-tieredmenu .p-menuitem-active>.p-submenu-list{display:block;left:100%;top:0}.p-toast{position:fixed;width:25rem}.p-toast-message-content{display:-ms-flexbox;display:flex;-ms-flex-align:start;align-items:flex-start}.p-toast-message-text{-ms-flex:1 1 auto;flex:1 1 auto}.p-toast-top-right{top:20px;right:20px}.p-toast-top-left{top:20px;left:20px}.p-toast-bottom-left{bottom:20px;left:20px}.p-toast-bottom-right{bottom:20px;right:20px}.p-toast-top-center{top:20px;left:50%;margin-left:-10em}.p-toast-bottom-center{bottom:20px;left:50%;margin-left:-10em}.p-toast-center{left:50%;top:50%;min-width:20vw;-webkit-transform:translate(-50%,-50%);transform:translate(-50%,-50%)}.p-toast-icon-close{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;overflow:hidden;position:relative}.p-toast-icon-close.p-link{cursor:pointer}.p-toast-message-enter{opacity:0;-webkit-transform:translateY(50%);transform:translateY(50%)}.p-toast-message-enter-active{opacity:1;-webkit-transform:translateY(0);transform:translateY(0);-webkit-transition:opacity .3s,-webkit-transform .3s;transition:opacity .3s,-webkit-transform .3s;transition:transform .3s,opacity .3s;transition:transform .3s,opacity .3s,-webkit-transform .3s}.p-toast-message-enter-done{-webkit-transform:none;transform:none}.p-toast-message-exit{opacity:1;max-height:1000px}.p-toast-message-exit-active{opacity:0;max-height:0;margin-bottom:0;overflow:hidden;-webkit-transition:max-height .45s cubic-bezier(0,1,0,1),opacity .3s,margin-bottom .3s;transition:max-height .45s cubic-bezier(0,1,0,1),opacity .3s,margin-bottom .3s}.p-toolbar{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:justify;justify-content:space-between}.p-toolbar-group-left,.p-toolbar-group-right{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-tree-container{margin:0;padding:0;list-style-type:none;overflow:auto}.p-treenode-children{margin:0;padding:0;list-style-type:none}.p-treenode-selectable{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-tree-toggler{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;overflow:hidden;position:relative}.p-treenode-leaf>.p-treenode-content .p-tree-toggler{visibility:hidden}.p-treenode-content{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.p-tree-filter{width:100%}.p-tree-filter-container{position:relative;display:block;width:100%}.p-tree-filter-icon{position:absolute;top:50%;margin-top:-.5rem}.p-tree-loading{position:relative;min-height:4rem}.p-tree .p-tree-loading-overlay{position:absolute;z-index:1;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center}.p-tooltip{position:absolute;padding:.25em .5rem;max-width:12.5rem}.p-tooltip.p-tooltip-right,.p-tooltip.p-tooltip-left{padding:0 .25rem}.p-tooltip.p-tooltip-top,.p-tooltip.p-tooltip-bottom{padding:.25em 0}.p-tooltip .p-tooltip-text{white-space:pre-line}.p-tooltip-arrow{position:absolute;width:0;height:0;border-color:transparent;border-style:solid}.p-tooltip-right .p-tooltip-arrow{top:50%;left:0;margin-top:-.25rem;border-width:.25em .25em .25em 0}.p-tooltip-left .p-tooltip-arrow{top:50%;right:0;margin-top:-.25rem;border-width:.25em 0 .25em .25rem}.p-tooltip.p-tooltip-top{padding:.25em 0}.p-tooltip-top .p-tooltip-arrow{bottom:0;left:50%;margin-left:-.25rem;border-width:.25em .25em 0}.p-tooltip-bottom .p-tooltip-arrow{top:0;left:50%;margin-left:-.25rem;border-width:0 .25em .25rem}.p-treetable{position:relative}.p-treetable table{border-collapse:collapse;width:100%;table-layout:fixed}.p-treetable .p-sortable-column{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.p-treetable-auto-layout>.p-treetable-wrapper{overflow-x:auto}.p-treetable-auto-layout>.p-treetable-wrapper>table{table-layout:auto}.p-treetable-hoverable-rows .p-treetable-tbody>tr{cursor:pointer}.p-treetable-toggler{cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;display:-ms-inline-flexbox;display:inline-flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;vertical-align:middle;overflow:hidden;position:relative}.p-treetable-toggler+.p-checkbox{vertical-align:middle}.p-treetable-toggler+.p-checkbox+span{vertical-align:middle}.p-treetable-resizable>.p-treetable-wrapper{overflow-x:auto}.p-treetable-resizable .p-treetable-thead>tr>th,.p-treetable-resizable .p-treetable-tfoot>tr>td,.p-treetable-resizable .p-treetable-tbody>tr>td{overflow:hidden}.p-treetable-resizable .p-resizable-column{background-clip:padding-box;position:relative}.p-treetable-resizable-fit .p-resizable-column:last-child .p-column-resizer{display:none}.p-treetable .p-column-resizer{display:block;position:absolute !important;top:0;right:0;margin:0;width:.5rem;height:100%;padding:0;cursor:col-resize;border:1px solid transparent}.p-treetable .p-column-resizer-helper{width:1px;position:absolute;z-index:10;display:none}.p-treetable-scrollable-wrapper{position:relative}.p-treetable-scrollable-header,.p-treetable-scrollable-footer{overflow:hidden;border:0 none}.p-treetable-scrollable-body{overflow:auto;position:relative}.p-treetable-virtual-table{position:absolute}.p-treetable-frozen-view .p-treetable-scrollable-body{overflow:hidden}.p-treetable-unfrozen-view{position:absolute;top:0;left:0}.p-treetable-reorder-indicator-up,.p-treetable-reorder-indicator-down{position:absolute;display:none}.p-treetable .p-treetable-loading-overlay{position:absolute;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;z-index:1}</style>
<style type="text/css">.p-grid {
  display: flex;
  flex-wrap: wrap;
  margin-right: -0.5rem;
  margin-left: -0.5rem;
  margin-top: -0.5rem;
}

.p-grid > .p-col,
.p-grid > [class*=p-col] {
  box-sizing: border-box;
}

.p-nogutter {
  margin-right: 0;
  margin-left: 0;
  margin-top: 0;
}

.p-nogutter > .p-col,
.p-nogutter > [class*=p-col-] {
  padding: 0;
}

.p-col {
  flex-grow: 1;
  flex-basis: 0;
  padding: 0.5rem;
}

.p-col-fixed {
  flex: 0 0 auto;
  padding: 0.5rem;
}

.p-col-1,
.p-col-2,
.p-col-3,
.p-col-4,
.p-col-5,
.p-col-6,
.p-col-7,
.p-col-8,
.p-col-9,
.p-col-10,
.p-col-11,
.p-col-12 {
  flex: 0 0 auto;
  padding: 0.5rem;
}

.p-col-1 {
  width: 8.3333%;
}

.p-col-2 {
  width: 16.6667%;
}

.p-col-3 {
  width: 25%;
}

.p-col-4 {
  width: 33.3333%;
}

.p-col-5 {
  width: 41.6667%;
}

.p-col-6 {
  width: 50%;
}

.p-col-7 {
  width: 58.3333%;
}

.p-col-8 {
  width: 66.6667%;
}

.p-col-9 {
  width: 75%;
}

.p-col-10 {
  width: 83.3333%;
}

.p-col-11 {
  width: 91.6667%;
}

.p-col-12 {
  width: 100%;
}

.p-offset-12 {
  margin-left: 100%;
}

.p-offset-11 {
  margin-left: 91.66666667%;
}

.p-offset-10 {
  margin-left: 83.33333333%;
}

.p-offset-9 {
  margin-left: 75%;
}

.p-offset-8 {
  margin-left: 66.66666667%;
}

.p-offset-7 {
  margin-left: 58.33333333%;
}

.p-offset-6 {
  margin-left: 50%;
}

.p-offset-5 {
  margin-left: 41.66666667%;
}

.p-offset-4 {
  margin-left: 33.33333333%;
}

.p-offset-3 {
  margin-left: 25%;
}

.p-offset-2 {
  margin-left: 16.66666667%;
}

.p-offset-1 {
  margin-left: 8.33333333%;
}

.p-offset-0 {
  margin-left: 0%;
}

.p-sm-1,
.p-sm-2,
.p-sm-3,
.p-sm-4,
.p-sm-5,
.p-sm-6,
.p-sm-7,
.p-sm-8,
.p-sm-9,
.p-sm-10,
.p-sm-11,
.p-sm-12,
.p-md-1,
.p-md-2,
.p-md-3,
.p-md-4,
.p-md-5,
.p-md-6,
.p-md-7,
.p-md-8,
.p-md-9,
.p-md-10,
.p-md-11,
.p-md-12,
.p-lg-1,
.p-lg-2,
.p-lg-3,
.p-lg-4,
.p-lg-5,
.p-lg-6,
.p-lg-7,
.p-lg-8,
.p-lg-9,
.p-lg-10,
.p-lg-11,
.p-lg-12,
.p-xl-1,
.p-xl-2,
.p-xl-3,
.p-xl-4,
.p-xl-5,
.p-xl-6,
.p-xl-7,
.p-xl-8,
.p-xl-9,
.p-xl-10,
.p-xl-11,
.p-xl-12 {
  padding: 0.5rem;
}

.p-col-nogutter {
  padding: 0;
}

@media screen and (min-width: 576px) {
  .p-sm-1,
.p-sm-2,
.p-sm-3,
.p-sm-4,
.p-sm-5,
.p-sm-6,
.p-sm-7,
.p-sm-8,
.p-sm-9,
.p-sm-10,
.p-sm-11,
.p-sm-12 {
    flex: 0 0 auto;
  }

  .p-sm-1 {
    width: 8.3333%;
  }

  .p-sm-2 {
    width: 16.6667%;
  }

  .p-sm-3 {
    width: 25%;
  }

  .p-sm-4 {
    width: 33.3333%;
  }

  .p-sm-5 {
    width: 41.6667%;
  }

  .p-sm-6 {
    width: 50%;
  }

  .p-sm-7 {
    width: 58.3333%;
  }

  .p-sm-8 {
    width: 66.6667%;
  }

  .p-sm-9 {
    width: 75%;
  }

  .p-sm-10 {
    width: 83.3333%;
  }

  .p-sm-11 {
    width: 91.6667%;
  }

  .p-sm-12 {
    width: 100%;
  }

  .p-sm-offset-12 {
    margin-left: 100%;
  }

  .p-sm-offset-11 {
    margin-left: 91.66666667%;
  }

  .p-sm-offset-10 {
    margin-left: 83.33333333%;
  }

  .p-sm-offset-9 {
    margin-left: 75%;
  }

  .p-sm-offset-8 {
    margin-left: 66.66666667%;
  }

  .p-sm-offset-7 {
    margin-left: 58.33333333%;
  }

  .p-sm-offset-6 {
    margin-left: 50%;
  }

  .p-sm-offset-5 {
    margin-left: 41.66666667%;
  }

  .p-sm-offset-4 {
    margin-left: 33.33333333%;
  }

  .p-sm-offset-3 {
    margin-left: 25%;
  }

  .p-sm-offset-2 {
    margin-left: 16.66666667%;
  }

  .p-sm-offset-1 {
    margin-left: 8.33333333%;
  }

  .p-sm-offset-0 {
    margin-left: 0%;
  }
}
@media screen and (min-width: 768px) {
  .p-md-1,
.p-md-2,
.p-md-3,
.p-md-4,
.p-md-5,
.p-md-6,
.p-md-7,
.p-md-8,
.p-md-9,
.p-md-10,
.p-md-11,
.p-md-12 {
    flex: 0 0 auto;
  }

  .p-md-1 {
    width: 8.3333%;
  }

  .p-md-2 {
    width: 16.6667%;
  }

  .p-md-3 {
    width: 25%;
  }

  .p-md-4 {
    width: 33.3333%;
  }

  .p-md-5 {
    width: 41.6667%;
  }

  .p-md-6 {
    width: 50%;
  }

  .p-md-7 {
    width: 58.3333%;
  }

  .p-md-8 {
    width: 66.6667%;
  }

  .p-md-9 {
    width: 75%;
  }

  .p-md-10 {
    width: 83.3333%;
  }

  .p-md-11 {
    width: 91.6667%;
  }

  .p-md-12 {
    width: 100%;
  }

  .p-md-offset-12 {
    margin-left: 100%;
  }

  .p-md-offset-11 {
    margin-left: 91.66666667%;
  }

  .p-md-offset-10 {
    margin-left: 83.33333333%;
  }

  .p-md-offset-9 {
    margin-left: 75%;
  }

  .p-md-offset-8 {
    margin-left: 66.66666667%;
  }

  .p-md-offset-7 {
    margin-left: 58.33333333%;
  }

  .p-md-offset-6 {
    margin-left: 50%;
  }

  .p-md-offset-5 {
    margin-left: 41.66666667%;
  }

  .p-md-offset-4 {
    margin-left: 33.33333333%;
  }

  .p-md-offset-3 {
    margin-left: 25%;
  }

  .p-md-offset-2 {
    margin-left: 16.66666667%;
  }

  .p-md-offset-1 {
    margin-left: 8.33333333%;
  }

  .p-md-offset-0 {
    margin-left: 0%;
  }
}
@media screen and (min-width: 992px) {
  .p-lg-1,
.p-lg-2,
.p-lg-3,
.p-lg-4,
.p-lg-5,
.p-lg-6,
.p-lg-7,
.p-lg-8,
.p-lg-9,
.p-lg-10,
.p-lg-11,
.p-lg-12 {
    flex: 0 0 auto;
  }

  .p-lg-1 {
    width: 8.3333%;
  }

  .p-lg-2 {
    width: 16.6667%;
  }

  .p-lg-3 {
    width: 25%;
  }

  .p-lg-4 {
    width: 33.3333%;
  }

  .p-lg-5 {
    width: 41.6667%;
  }

  .p-lg-6 {
    width: 50%;
  }

  .p-lg-7 {
    width: 58.3333%;
  }

  .p-lg-8 {
    width: 66.6667%;
  }

  .p-lg-9 {
    width: 75%;
  }

  .p-lg-10 {
    width: 83.3333%;
  }

  .p-lg-11 {
    width: 91.6667%;
  }

  .p-lg-12 {
    width: 100%;
  }

  .p-lg-offset-12 {
    margin-left: 100%;
  }

  .p-lg-offset-11 {
    margin-left: 91.66666667%;
  }

  .p-lg-offset-10 {
    margin-left: 83.33333333%;
  }

  .p-lg-offset-9 {
    margin-left: 75%;
  }

  .p-lg-offset-8 {
    margin-left: 66.66666667%;
  }

  .p-lg-offset-7 {
    margin-left: 58.33333333%;
  }

  .p-lg-offset-6 {
    margin-left: 50%;
  }

  .p-lg-offset-5 {
    margin-left: 41.66666667%;
  }

  .p-lg-offset-4 {
    margin-left: 33.33333333%;
  }

  .p-lg-offset-3 {
    margin-left: 25%;
  }

  .p-lg-offset-2 {
    margin-left: 16.66666667%;
  }

  .p-lg-offset-1 {
    margin-left: 8.33333333%;
  }

  .p-lg-offset-0 {
    margin-left: 0%;
  }
}
@media screen and (min-width: 1200px) {
  .p-xl-1,
.p-xl-2,
.p-xl-3,
.p-xl-4,
.p-xl-5,
.p-xl-6,
.p-xl-7,
.p-xl-8,
.p-xl-9,
.p-xl-10,
.p-xl-11,
.p-xl-12 {
    flex: 0 0 auto;
  }

  .p-xl-1 {
    width: 8.3333%;
  }

  .p-xl-2 {
    width: 16.6667%;
  }

  .p-xl-3 {
    width: 25%;
  }

  .p-xl-4 {
    width: 33.3333%;
  }

  .p-xl-5 {
    width: 41.6667%;
  }

  .p-xl-6 {
    width: 50%;
  }

  .p-xl-7 {
    width: 58.3333%;
  }

  .p-xl-8 {
    width: 66.6667%;
  }

  .p-xl-9 {
    width: 75%;
  }

  .p-xl-10 {
    width: 83.3333%;
  }

  .p-xl-11 {
    width: 91.6667%;
  }

  .p-xl-12 {
    width: 100%;
  }

  .p-xl-offset-12 {
    margin-left: 100%;
  }

  .p-xl-offset-11 {
    margin-left: 91.66666667%;
  }

  .p-xl-offset-10 {
    margin-left: 83.33333333%;
  }

  .p-xl-offset-9 {
    margin-left: 75%;
  }

  .p-xl-offset-8 {
    margin-left: 66.66666667%;
  }

  .p-xl-offset-7 {
    margin-left: 58.33333333%;
  }

  .p-xl-offset-6 {
    margin-left: 50%;
  }

  .p-xl-offset-5 {
    margin-left: 41.66666667%;
  }

  .p-xl-offset-4 {
    margin-left: 33.33333333%;
  }

  .p-xl-offset-3 {
    margin-left: 25%;
  }

  .p-xl-offset-2 {
    margin-left: 16.66666667%;
  }

  .p-xl-offset-1 {
    margin-left: 8.33333333%;
  }

  .p-xl-offset-0 {
    margin-left: 0%;
  }
}
.p-justify-start {
  justify-content: flex-start;
}

.p-justify-end {
  justify-content: flex-end;
}

.p-justify-center {
  justify-content: center;
}

.p-justify-between {
  justify-content: space-between;
}

.p-justify-around {
  justify-content: space-around;
}

.p-justify-even {
  justify-content: space-evenly;
}

.p-align-start {
  align-items: flex-start;
}

.p-align-end {
  align-items: flex-end;
}

.p-align-center {
  align-items: center;
}

.p-align-baseline {
  align-items: baseline;
}

.p-align-stretch {
  align-items: stretch;
}

.p-col-align-start {
  align-self: flex-start;
}

.p-col-align-end {
  align-self: flex-end;
}

.p-col-align-center {
  align-self: center;
}

.p-col-align-baseline {
  align-self: baseline;
}

.p-col-align-stretch {
  align-self: stretch;
}

.p-dir-row {
  flex-direction: row;
}

.p-dir-rev {
  flex-direction: row-reverse;
}

.p-dir-col {
  flex-direction: column;
}

.p-dir-col-rev {
  flex-direction: column-reverse;
}

.p-dir-col > .p-col,
.p-dir-col-rev > .p-col {
  flex-basis: auto;
}

.p-col-order-first {
  order: -1;
}

.p-col-order-last {
  order: 13;
}

.p-col-order-0 {
  order: 0;
}

.p-col-order-1 {
  order: 1;
}

.p-col-order-2 {
  order: 2;
}

.p-col-order-3 {
  order: 3;
}

.p-col-order-4 {
  order: 4;
}

.p-col-order-5 {
  order: 5;
}

.p-col-order-6 {
  order: 6;
}

.p-col-order-7 {
  order: 7;
}

.p-col-order-8 {
  order: 8;
}

.p-col-order-9 {
  order: 9;
}

.p-col-order-10 {
  order: 10;
}

.p-col-order-11 {
  order: 11;
}

.p-col-order-12 {
  order: 12;
}

@media screen and (min-width: 576px) {
  .p-sm-order-first {
    order: -1;
  }

  .p-sm-order-last {
    order: 13;
  }

  .p-sm-order-0 {
    order: 0;
  }

  .p-sm-order-1 {
    order: 1;
  }

  .p-sm-order-2 {
    order: 2;
  }

  .p-sm-order-3 {
    order: 3;
  }

  .p-sm-order-4 {
    order: 4;
  }

  .p-sm-order-5 {
    order: 5;
  }

  .p-sm-order-6 {
    order: 6;
  }

  .p-sm-order-7 {
    order: 7;
  }

  .p-sm-order-8 {
    order: 8;
  }

  .p-sm-order-9 {
    order: 9;
  }

  .p-sm-order-10 {
    order: 10;
  }

  .p-sm-order-11 {
    order: 11;
  }

  .p-sm-order-12 {
    order: 12;
  }
}
@media screen and (min-width: 768px) {
  .p-md-order-first {
    order: -1;
  }

  .p-md-order-last {
    order: 13;
  }

  .p-md-order-0 {
    order: 0;
  }

  .p-md-order-1 {
    order: 1;
  }

  .p-md-order-2 {
    order: 2;
  }

  .p-md-order-3 {
    order: 3;
  }

  .p-md-order-4 {
    order: 4;
  }

  .p-md-order-5 {
    order: 5;
  }

  .p-md-order-6 {
    order: 6;
  }

  .p-md-order-7 {
    order: 7;
  }

  .p-md-order-8 {
    order: 8;
  }

  .p-md-order-9 {
    order: 9;
  }

  .p-md-order-10 {
    order: 10;
  }

  .p-md-order-11 {
    order: 11;
  }

  .p-md-order-12 {
    order: 12;
  }
}
@media screen and (min-width: 992px) {
  .p-lg-order-first {
    order: -1;
  }

  .p-lg-order-last {
    order: 13;
  }

  .p-lg-order-0 {
    order: 0;
  }

  .p-lg-order-1 {
    order: 1;
  }

  .p-lg-order-2 {
    order: 2;
  }

  .p-lg-order-3 {
    order: 3;
  }

  .p-lg-order-4 {
    order: 4;
  }

  .p-lg-order-5 {
    order: 5;
  }

  .p-lg-order-6 {
    order: 6;
  }

  .p-lg-order-7 {
    order: 7;
  }

  .p-lg-order-8 {
    order: 8;
  }

  .p-lg-order-9 {
    order: 9;
  }

  .p-lg-order-10 {
    order: 10;
  }

  .p-lg-order-11 {
    order: 11;
  }

  .p-lg-order-12 {
    order: 12;
  }
}
@media screen and (min-width: 1200px) {
  .p-xl-order-first {
    order: -1;
  }

  .p-xl-order-last {
    order: 13;
  }

  .p-xl-order-0 {
    order: 0;
  }

  .p-xl-order-1 {
    order: 1;
  }

  .p-xl-order-2 {
    order: 2;
  }

  .p-xl-order-3 {
    order: 3;
  }

  .p-xl-order-4 {
    order: 4;
  }

  .p-xl-order-5 {
    order: 5;
  }

  .p-xl-order-6 {
    order: 6;
  }

  .p-xl-order-7 {
    order: 7;
  }

  .p-xl-order-8 {
    order: 8;
  }

  .p-xl-order-9 {
    order: 9;
  }

  .p-xl-order-10 {
    order: 10;
  }

  .p-xl-order-11 {
    order: 11;
  }

  .p-xl-order-12 {
    order: 12;
  }
}
.p-field {
  margin-bottom: 1rem;
}

.p-field > label {
  display: inline-block;
  margin-bottom: 0.5rem;
}

.p-field.p-grid > label {
  display: flex;
  align-items: center;
}

.p-field > small {
  margin-top: 0.25rem;
}

.p-field.p-grid,
.p-formgrid.p-grid {
  margin-top: 0;
}

.p-field.p-grid .p-col-fixed,
.p-formgrid.p-grid .p-col-fixed,
.p-field.p-grid .p-col,
.p-formgrid.p-grid .p-col,
.p-field.p-grid .p-col-1,
.p-formgrid.p-grid .p-col-1,
.p-field.p-grid .p-col-2,
.p-formgrid.p-grid .p-col-2,
.p-field.p-grid .p-col-3,
.p-formgrid.p-grid .p-col-3,
.p-field.p-grid .p-col-4,
.p-formgrid.p-grid .p-col-4,
.p-field.p-grid .p-col-5,
.p-formgrid.p-grid .p-col-5,
.p-field.p-grid .p-col-6,
.p-formgrid.p-grid .p-col-6,
.p-field.p-grid .p-col-7,
.p-formgrid.p-grid .p-col-7,
.p-field.p-grid .p-col-8,
.p-formgrid.p-grid .p-col-8,
.p-field.p-grid .p-col-9,
.p-formgrid.p-grid .p-col-9,
.p-field.p-grid .p-col-10,
.p-formgrid.p-grid .p-col-10,
.p-field.p-grid .p-col-11,
.p-formgrid.p-grid .p-col-11,
.p-field.p-grid .p-col-12,
.p-formgrid.p-grid .p-col-12 {
  padding-top: 0;
  padding-bottom: 0;
}

.p-formgroup-inline {
  display: flex;
  flex-wrap: wrap;
  align-items: flex-start;
}

.p-formgroup-inline .p-field,
.p-formgroup-inline .p-field-checkbox,
.p-formgroup-inline .p-field-radiobutton {
  margin-right: 1rem;
}

.p-formgroup-inline .p-field > label,
.p-formgroup-inline .p-field-checkbox > label,
.p-formgroup-inline .p-field-radiobutton > label {
  margin-right: 0.5rem;
  margin-bottom: 0;
}

.p-field-checkbox,
.p-field-radiobutton {
  margin-bottom: 1rem;
  display: flex;
  align-items: center;
}

.p-field-checkbox > label,
.p-field-radiobutton > label {
  margin-left: 0.5rem;
  line-height: 1;
}

.p-d-none {
  display: none !important;
}

.p-d-inline {
  display: inline !important;
}

.p-d-inline-block {
  display: inline-block !important;
}

.p-d-block {
  display: block !important;
}

.p-d-flex {
  display: flex !important;
}

.p-d-inline-flex {
  display: inline-flex !important;
}

@media screen and (min-width: 576px) {
  .p-d-sm-none {
    display: none !important;
  }

  .p-d-sm-inline {
    display: inline !important;
  }

  .p-d-sm-inline-block {
    display: inline-block !important;
  }

  .p-d-sm-block {
    display: block !important;
  }

  .p-d-sm-flex {
    display: flex !important;
  }

  .p-d-sm-inline-flex {
    display: inline-flex !important;
  }
}
@media screen and (min-width: 768px) {
  .p-d-md-none {
    display: none !important;
  }

  .p-d-md-inline {
    display: inline !important;
  }

  .p-d-md-inline-block {
    display: inline-block !important;
  }

  .p-d-md-block {
    display: block !important;
  }

  .p-d-md-flex {
    display: flex !important;
  }

  .p-d-md-inline-flex {
    display: inline-flex !important;
  }
}
@media screen and (min-width: 992px) {
  .p-d-lg-none {
    display: none !important;
  }

  .p-d-lg-inline {
    display: inline !important;
  }

  .p-d-lg-inline-block {
    display: inline-block !important;
  }

  .p-d-lg-block {
    display: block !important;
  }

  .p-d-lg-flex {
    display: flex !important;
  }

  .p-d-lg-inline-flex {
    display: inline-flex !important;
  }
}
@media screen and (min-width: 1200px) {
  .p-d-xl-none {
    display: none !important;
  }

  .p-d-xl-inline {
    display: inline !important;
  }

  .p-d-xl-inline-block {
    display: inline-block !important;
  }

  .p-d-xl-block {
    display: block !important;
  }

  .p-d-xl-flex {
    display: flex !important;
  }

  .p-d-xl-inline-flex {
    display: inline-flex !important;
  }
}
@media print {
  .p-d-print-none {
    display: none !important;
  }

  .p-d-print-inline {
    display: inline !important;
  }

  .p-d-print-inline-block {
    display: inline-block !important;
  }

  .p-d-print-block {
    display: block !important;
  }

  .p-d-print-flex {
    display: flex !important;
  }

  .p-d-print-inline-flex {
    display: inline-flex !important;
  }
}
.p-text-justify {
  text-align: justify !important;
}

.p-text-left {
  text-align: left !important;
}

.p-text-right {
  text-align: right !important;
}

.p-text-center {
  text-align: center !important;
}

.p-text-nowrap {
  white-space: nowrap !important;
}

.p-text-truncate {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.p-text-lowercase {
  text-transform: lowercase !important;
}

.p-text-uppercase {
  text-transform: uppercase !important;
}

.p-text-capitalize {
  text-transform: capitalize !important;
}

.p-text-bold {
  font-weight: 700 !important;
}

.p-text-normal {
  font-weight: 400 !important;
}

.p-text-light {
  font-weight: 300 !important;
}

.p-text-italic {
  font-style: italic !important;
}

@media screen and (min-width: 576px) {
  .p-text-sm-justify {
    text-align: justify !important;
  }

  .p-text-sm-left {
    text-align: left !important;
  }

  .p-text-sm-right {
    text-align: right !important;
  }

  .p-text-sm-center {
    text-align: center !important;
  }
}
@media screen and (min-width: 768px) {
  .p-text-md-justify {
    text-align: justify !important;
  }

  .p-text-md-left {
    text-align: left !important;
  }

  .p-text-md-right {
    text-align: right !important;
  }

  .p-text-md-center {
    text-align: center !important;
  }
}
@media screen and (min-width: 992px) {
  .p-text-lg-justify {
    text-align: justify !important;
  }

  .p-text-lg-left {
    text-align: left !important;
  }

  .p-text-lg-right {
    text-align: right !important;
  }

  .p-text-lg-center {
    text-align: center !important;
  }
}
@media screen and (min-width: 1200px) {
  .p-text-xl-justify {
    text-align: justify !important;
  }

  .p-text-xl-left {
    text-align: left !important;
  }

  .p-text-xl-right {
    text-align: right !important;
  }

  .p-text-xl-center {
    text-align: center !important;
  }
}
.p-flex-row {
  flex-direction: row !important;
}

.p-flex-row-reverse {
  flex-direction: row-reverse !important;
}

.p-flex-column {
  flex-direction: column !important;
}

.p-flex-column-reverse {
  flex-direction: column-reverse !important;
}

@media screen and (min-width: 576px) {
  .p-flex-sm-row {
    flex-direction: row !important;
  }

  .p-flex-sm-row-reverse {
    flex-direction: row-reverse !important;
  }

  .p-flex-sm-column {
    flex-direction: column !important;
  }

  .p-flex-sm-column-reverse {
    flex-direction: column-reverse !important;
  }
}
@media screen and (min-width: 768px) {
  .p-flex-md-row {
    flex-direction: row !important;
  }

  .p-flex-md-row-reverse {
    flex-direction: row-reverse !important;
  }

  .p-flex-md-column {
    flex-direction: column !important;
  }

  .p-flex-md-column-reverse {
    flex-direction: column-reverse !important;
  }
}
@media screen and (min-width: 992px) {
  .p-flex-lg-row {
    flex-direction: row !important;
  }

  .p-flex-lg-row-reverse {
    flex-direction: row-reverse !important;
  }

  .p-flex-lg-column {
    flex-direction: column !important;
  }

  .p-flex-lg-column-reverse {
    flex-direction: column-reverse !important;
  }
}
@media screen and (min-width: 1200px) {
  .p-flex-xl-row {
    flex-direction: row !important;
  }

  .p-flex-xl-row-reverse {
    flex-direction: row-reverse !important;
  }

  .p-flex-xl-column {
    flex-direction: column !important;
  }

  .p-flex-xl-column-reverse {
    flex-direction: column-reverse !important;
  }
}
.p-jc-start {
  justify-content: flex-start;
}

.p-jc-end {
  justify-content: flex-end;
}

.p-jc-center {
  justify-content: center;
}

.p-jc-between {
  justify-content: space-between;
}

.p-jc-around {
  justify-content: space-around;
}

.p-jc-evenly {
  justify-content: space-evenly;
}

@media screen and (min-width: 576px) {
  .p-jc-sm-start {
    justify-content: flex-start;
  }

  .p-jc-sm-end {
    justify-content: flex-end;
  }

  .p-jc-sm-center {
    justify-content: center;
  }

  .p-jc-sm-between {
    justify-content: space-between;
  }

  .p-jc-sm-around {
    justify-content: space-around;
  }

  .p-jc-sm-evenly {
    justify-content: space-evenly;
  }
}
@media screen and (min-width: 768px) {
  .p-jc-md-start {
    justify-content: flex-start;
  }

  .p-jc-md-end {
    justify-content: flex-end;
  }

  .p-jc-md-center {
    justify-content: center;
  }

  .p-jc-md-between {
    justify-content: space-between;
  }

  .p-jc-md-around {
    justify-content: space-around;
  }

  .p-jc-md-evenly {
    justify-content: space-evenly;
  }
}
@media screen and (min-width: 992px) {
  .p-jc-lg-start {
    justify-content: flex-start;
  }

  .p-jc-lg-end {
    justify-content: flex-end;
  }

  .p-jc-lg-center {
    justify-content: center;
  }

  .p-jc-lg-between {
    justify-content: space-between;
  }

  .p-jc-lg-around {
    justify-content: space-around;
  }

  .p-jc-lg-evenly {
    justify-content: space-evenly;
  }
}
@media screen and (min-width: 1200px) {
  .p-jc-xl-start {
    justify-content: flex-start;
  }

  .p-jc-xl-end {
    justify-content: flex-end;
  }

  .p-jc-xl-center {
    justify-content: center;
  }

  .p-jc-xl-between {
    justify-content: space-between;
  }

  .p-jc-xl-around {
    justify-content: space-around;
  }

  .p-jc-xl-evenly {
    justify-content: space-evenly;
  }
}
.p-ai-start {
  align-items: flex-start;
}

.p-ai-end {
  align-items: flex-end;
}

.p-ai-center {
  align-items: center;
}

.p-ai-baseline {
  align-items: baseline;
}

.p-ai-stretch {
  align-items: stretch;
}

@media screen and (min-width: 576px) {
  .p-ai-sm-start {
    align-items: flex-start;
  }

  .p-ai-sm-end {
    align-items: flex-end;
  }

  .p-ai-sm-center {
    align-items: center;
  }

  .p-ai-sm-baseline {
    align-items: baseline;
  }

  .p-ai-sm-stretch {
    align-items: stretch;
  }
}
@media screen and (min-width: 768px) {
  .p-ai-md-start {
    align-items: flex-start;
  }

  .p-ai-md-end {
    align-items: flex-end;
  }

  .p-ai-md-center {
    align-items: center;
  }

  .p-ai-md-baseline {
    align-items: baseline;
  }

  .p-ai-md-stretch {
    align-items: stretch;
  }
}
@media screen and (min-width: 992px) {
  .p-ai-lg-start {
    align-items: flex-start;
  }

  .p-ai-lg-end {
    align-items: flex-end;
  }

  .p-ai-lg-center {
    align-items: center;
  }

  .p-ai-lg-baseline {
    align-items: baseline;
  }

  .p-ai-lg-stretch {
    align-items: stretch;
  }
}
@media screen and (min-width: 1200px) {
  .p-ai-xl-start {
    align-items: flex-start;
  }

  .p-ai-xl-end {
    align-items: flex-end;
  }

  .p-ai-xl-center {
    align-items: center;
  }

  .p-ai-xl-baseline {
    align-items: baseline;
  }

  .p-ai-xl-stretch {
    align-items: stretch;
  }
}
.p-as-start {
  align-self: start;
}

.p-as-end {
  align-self: flex-end;
}

.p-as-center {
  align-self: center;
}

.p-as-baseline {
  align-self: baseline;
}

.p-as-stretch {
  align-self: stretch;
}

@media screen and (min-width: 576px) {
  .p-as-sm-start {
    align-self: start;
  }

  .p-as-sm-end {
    align-self: flex-end;
  }

  .p-as-sm-center {
    align-self: center;
  }

  .p-as-sm-baseline {
    align-self: baseline;
  }

  .p-as-sm-stretch {
    align-self: stretch;
  }
}
@media screen and (min-width: 768px) {
  .p-as-md-start {
    align-self: start;
  }

  .p-as-md-end {
    align-self: flex-end;
  }

  .p-as-md-center {
    align-self: center;
  }

  .p-as-md-baseline {
    align-self: baseline;
  }

  .p-as-md-stretch {
    align-self: stretch;
  }
}
@media screen and (min-width: 992px) {
  .p-as-lg-start {
    align-self: start;
  }

  .p-as-lg-end {
    align-self: flex-end;
  }

  .p-as-lg-center {
    align-self: center;
  }

  .p-as-lg-baseline {
    align-self: baseline;
  }

  .p-as-lg-stretch {
    align-self: stretch;
  }
}
@media screen and (min-width: 1200px) {
  .p-as-xl-start {
    align-self: start;
  }

  .p-as-xl-end {
    align-self: flex-end;
  }

  .p-as-xl-center {
    align-self: center;
  }

  .p-as-xl-baseline {
    align-self: baseline;
  }

  .p-as-xl-stretch {
    align-self: stretch;
  }
}
.p-ac-start {
  align-content: flex-start;
}

.p-ac-end {
  align-content: flex-end;
}

.p-ac-center {
  align-content: center;
}

.p-ac-around {
  align-content: space-around;
}

.p-ac-stretch {
  align-content: stretch;
}

.p-ac-between {
  align-content: space-between;
}

@media screen and (min-width: 576px) {
  .p-ac-sm-start {
    align-content: flex-start;
  }

  .p-ac-sm-end {
    align-content: flex-end;
  }

  .p-ac-sm-center {
    align-content: center;
  }

  .p-ac-sm-around {
    align-content: space-around;
  }

  .p-ac-sm-stretch {
    align-content: stretch;
  }

  .p-ac-sm-between {
    align-content: space-between;
  }
}
@media screen and (min-width: 768px) {
  .p-ac-md-start {
    align-content: flex-start;
  }

  .p-ac-md-end {
    align-content: flex-end;
  }

  .p-ac-md-center {
    align-content: center;
  }

  .p-ac-md-around {
    align-content: space-around;
  }

  .p-ac-md-stretch {
    align-content: stretch;
  }

  .p-ac-md-between {
    align-content: space-between;
  }
}
@media screen and (min-width: 992px) {
  .p-ac-lg-start {
    align-content: flex-start;
  }

  .p-ac-lg-end {
    align-content: flex-end;
  }

  .p-ac-lg-center {
    align-content: center;
  }

  .p-ac-lg-around {
    align-content: space-around;
  }

  .p-ac-lg-stretch {
    align-content: stretch;
  }

  .p-ac-lg-between {
    align-content: space-between;
  }
}
@media screen and (min-width: 1200px) {
  .p-ac-xl-start {
    align-content: flex-start;
  }

  .p-ac-xl-end {
    align-content: flex-end;
  }

  .p-ac-xl-center {
    align-content: center;
  }

  .p-ac-xl-around {
    align-content: space-around;
  }

  .p-ac-xl-stretch {
    align-content: stretch;
  }

  .p-ac-xl-between {
    align-content: space-between;
  }
}
.p-order-0 {
  order: 0;
}

.p-order-1 {
  order: 1;
}

.p-order-2 {
  order: 2;
}

.p-order-3 {
  order: 3;
}

.p-order-4 {
  order: 4;
}

.p-order-5 {
  order: 5;
}

.p-order-6 {
  order: 6;
}

@media screen and (min-width: 576px) {
  .p-order-sm-0 {
    order: 0;
  }

  .p-order-sm-1 {
    order: 1;
  }

  .p-order-sm-2 {
    order: 2;
  }

  .p-order-sm-3 {
    order: 3;
  }

  .p-order-sm-4 {
    order: 4;
  }

  .p-order-sm-5 {
    order: 5;
  }

  .p-order-sm-6 {
    order: 6;
  }
}
@media screen and (min-width: 768px) {
  .p-order-md-0 {
    order: 0;
  }

  .p-order-md-1 {
    order: 1;
  }

  .p-order-md-2 {
    order: 2;
  }

  .p-order-md-3 {
    order: 3;
  }

  .p-order-md-4 {
    order: 4;
  }

  .p-order-md-5 {
    order: 5;
  }

  .p-order-md-6 {
    order: 6;
  }
}
@media screen and (min-width: 992px) {
  .p-order-lg-0 {
    order: 0;
  }

  .p-order-lg-1 {
    order: 1;
  }

  .p-order-lg-2 {
    order: 2;
  }

  .p-order-lg-3 {
    order: 3;
  }

  .p-order-lg-4 {
    order: 4;
  }

  .p-order-lg-5 {
    order: 5;
  }

  .p-order-lg-6 {
    order: 6;
  }
}
@media screen and (min-width: 1200px) {
  .p-order-xl-0 {
    order: 0;
  }

  .p-order-xl-1 {
    order: 1;
  }

  .p-order-xl-2 {
    order: 2;
  }

  .p-order-xl-3 {
    order: 3;
  }

  .p-order-xl-4 {
    order: 4;
  }

  .p-order-xl-5 {
    order: 5;
  }

  .p-order-xl-6 {
    order: 6;
  }
}
.p-flex-nowrap {
  flex-wrap: nowrap;
}

.p-flex-wrap {
  flex-wrap: wrap;
}

.p-flex-wrap-reverse {
  flex-wrap: wrap-reverse;
}

@media screen and (min-width: 576px) {
  .p-flex-sm-nowrap {
    flex-wrap: nowrap;
  }

  .p-flex-sm-wrap {
    flex-wrap: wrap;
  }

  .p-flex-sm-wrap-reverse {
    flex-wrap: wrap-reverse;
  }
}
@media screen and (min-width: 768px) {
  .p-flex-md-nowrap {
    flex-wrap: nowrap;
  }

  .p-flex-md-wrap {
    flex-wrap: wrap;
  }

  .p-flex-md-wrap-reverse {
    flex-wrap: wrap-reverse;
  }
}
@media screen and (min-width: 992px) {
  .p-flex-lg-nowrap {
    flex-wrap: nowrap;
  }

  .p-flex-lg-wrap {
    flex-wrap: wrap;
  }

  .p-flex-lg-wrap-reverse {
    flex-wrap: wrap-reverse;
  }
}
@media screen and (min-width: 1200px) {
  .p-flex-xl-nowrap {
    flex-wrap: nowrap;
  }

  .p-flex-xl-wrap {
    flex-wrap: wrap;
  }

  .p-flex-xl-wrap-reverse {
    flex-wrap: wrap-reverse;
  }
}
.p-pt-0 {
  padding-top: 0 !important;
}

.p-pt-1 {
  padding-top: 0.25rem !important;
}

.p-pt-2 {
  padding-top: 0.5rem !important;
}

.p-pt-3 {
  padding-top: 1rem !important;
}

.p-pt-4 {
  padding-top: 1.5rem !important;
}

.p-pt-5 {
  padding-top: 2rem !important;
}

.p-pt-6 {
  padding-top: 3rem !important;
}

.p-pr-0 {
  padding-right: 0 !important;
}

.p-pr-1 {
  padding-right: 0.25rem !important;
}

.p-pr-2 {
  padding-right: 0.5rem !important;
}

.p-pr-3 {
  padding-right: 1rem !important;
}

.p-pr-4 {
  padding-right: 1.5rem !important;
}

.p-pr-5 {
  padding-right: 2rem !important;
}

.p-pr-6 {
  padding-right: 3rem !important;
}

.p-pl-0 {
  padding-left: 0 !important;
}

.p-pl-1 {
  padding-left: 0.25rem !important;
}

.p-pl-2 {
  padding-left: 0.5rem !important;
}

.p-pl-3 {
  padding-left: 1rem !important;
}

.p-pl-4 {
  padding-left: 1.5rem !important;
}

.p-pl-5 {
  padding-left: 2rem !important;
}

.p-pl-6 {
  padding-left: 3rem !important;
}

.p-pb-0 {
  padding-bottom: 0 !important;
}

.p-pb-1 {
  padding-bottom: 0.25rem !important;
}

.p-pb-2 {
  padding-bottom: 0.5rem !important;
}

.p-pb-3 {
  padding-bottom: 1rem !important;
}

.p-pb-4 {
  padding-bottom: 1.5rem !important;
}

.p-pb-5 {
  padding-bottom: 2rem !important;
}

.p-pb-6 {
  padding-bottom: 3rem !important;
}

.p-px-0 {
  padding-left: 0 !important;
  padding-right: 0 !important;
}

.p-px-1 {
  padding-left: 0.25rem !important;
  padding-right: 0.25rem !important;
}

.p-px-2 {
  padding-left: 0.5rem !important;
  padding-right: 0.5rem !important;
}

.p-px-3 {
  padding-left: 1rem !important;
  padding-right: 1rem !important;
}

.p-px-4 {
  padding-left: 1.5rem !important;
  padding-right: 1.5rem !important;
}

.p-px-5 {
  padding-left: 2rem !important;
  padding-right: 2rem !important;
}

.p-px-6 {
  padding-left: 3rem !important;
  padding-right: 3rem !important;
}

.p-py-0 {
  padding-top: 0 !important;
  padding-bottom: 0 !important;
}

.p-py-1 {
  padding-top: 0.25rem !important;
  padding-bottom: 0.25rem !important;
}

.p-py-2 {
  padding-top: 0.5rem !important;
  padding-bottom: 0.5rem !important;
}

.p-py-3 {
  padding-top: 1rem !important;
  padding-bottom: 1rem !important;
}

.p-py-4 {
  padding-top: 1.5rem !important;
  padding-bottom: 1.5rem !important;
}

.p-py-5 {
  padding-top: 2rem !important;
  padding-bottom: 2rem !important;
}

.p-py-6 {
  padding-top: 3rem !important;
  padding-bottom: 3rem !important;
}

.p-p-0 {
  padding: 0 !important;
}

.p-p-1 {
  padding: 0.25rem !important;
}

.p-p-2 {
  padding: 0.5rem !important;
}

.p-p-3 {
  padding: 1rem !important;
}

.p-p-4 {
  padding: 1.5rem !important;
}

.p-p-5 {
  padding: 2rem !important;
}

.p-p-6 {
  padding: 3rem !important;
}

@media screen and (min-width: 576px) {
  .p-pt-sm-0 {
    padding-top: 0 !important;
  }

  .p-pt-sm-1 {
    padding-top: 0.25rem !important;
  }

  .p-pt-sm-2 {
    padding-top: 0.5rem !important;
  }

  .p-pt-sm-3 {
    padding-top: 1rem !important;
  }

  .p-pt-sm-4 {
    padding-top: 1.5rem !important;
  }

  .p-pt-sm-5 {
    padding-top: 2rem !important;
  }

  .p-pt-sm-6 {
    padding-top: 3rem !important;
  }

  .p-pr-sm-0 {
    padding-right: 0 !important;
  }

  .p-pr-sm-1 {
    padding-right: 0.25rem !important;
  }

  .p-pr-sm-2 {
    padding-right: 0.5rem !important;
  }

  .p-pr-sm-3 {
    padding-right: 1rem !important;
  }

  .p-pr-sm-4 {
    padding-right: 1.5rem !important;
  }

  .p-pr-sm-5 {
    padding-right: 2rem !important;
  }

  .p-pr-sm-6 {
    padding-right: 3rem !important;
  }

  .p-pl-sm-0 {
    padding-left: 0 !important;
  }

  .p-pl-sm-1 {
    padding-left: 0.25rem !important;
  }

  .p-pl-sm-2 {
    padding-left: 0.5rem !important;
  }

  .p-pl-sm-3 {
    padding-left: 1rem !important;
  }

  .p-pl-sm-4 {
    padding-left: 1.5rem !important;
  }

  .p-pl-sm-5 {
    padding-left: 2rem !important;
  }

  .p-pl-sm-6 {
    padding-left: 3rem !important;
  }

  .p-pb-sm-0 {
    padding-bottom: 0 !important;
  }

  .p-pb-sm-1 {
    padding-bottom: 0.25rem !important;
  }

  .p-pb-sm-2 {
    padding-bottom: 0.5rem !important;
  }

  .p-pb-sm-3 {
    padding-bottom: 1rem !important;
  }

  .p-pb-sm-4 {
    padding-bottom: 1.5rem !important;
  }

  .p-pb-sm-5 {
    padding-bottom: 2rem !important;
  }

  .p-pb-sm-6 {
    padding-bottom: 3rem !important;
  }

  .p-px-sm-0 {
    padding-left: 0 !important;
    padding-right: 0 !important;
  }

  .p-px-sm-1 {
    padding-left: 0.25rem !important;
    padding-right: 0.25rem !important;
  }

  .p-px-sm-2 {
    padding-left: 0.5rem !important;
    padding-right: 0.5rem !important;
  }

  .p-px-sm-3 {
    padding-left: 1rem !important;
    padding-right: 1rem !important;
  }

  .p-px-sm-4 {
    padding-left: 1.5rem !important;
    padding-right: 1.5rem !important;
  }

  .p-px-sm-5 {
    padding-left: 2rem !important;
    padding-right: 2rem !important;
  }

  .p-px-sm-6 {
    padding-left: 3rem !important;
    padding-right: 3rem !important;
  }

  .p-py-sm-0 {
    padding-top: 0 !important;
    padding-bottom: 0 !important;
  }

  .p-py-sm-1 {
    padding-top: 0.25rem !important;
    padding-bottom: 0.25rem !important;
  }

  .p-py-sm-2 {
    padding-top: 0.5rem !important;
    padding-bottom: 0.5rem !important;
  }

  .p-py-sm-3 {
    padding-top: 1rem !important;
    padding-bottom: 1rem !important;
  }

  .p-py-sm-4 {
    padding-top: 1.5rem !important;
    padding-bottom: 1.5rem !important;
  }

  .p-py-sm-5 {
    padding-top: 2rem !important;
    padding-bottom: 2rem !important;
  }

  .p-py-sm-6 {
    padding-top: 3rem !important;
    padding-bottom: 3rem !important;
  }

  .p-p-sm-0 {
    padding: 0 !important;
  }

  .p-p-sm-1 {
    padding: 0.25rem !important;
  }

  .p-p-sm-2 {
    padding: 0.5rem !important;
  }

  .p-p-sm-3 {
    padding: 1rem !important;
  }

  .p-p-sm-4 {
    padding: 1.5rem !important;
  }

  .p-p-sm-5 {
    padding: 2rem !important;
  }

  .p-p-sm-6 {
    padding: 3rem !important;
  }
}
@media screen and (min-width: 768px) {
  .p-pt-md-0 {
    padding-top: 0 !important;
  }

  .p-pt-md-1 {
    padding-top: 0.25rem !important;
  }

  .p-pt-md-2 {
    padding-top: 0.5rem !important;
  }

  .p-pt-md-3 {
    padding-top: 1rem !important;
  }

  .p-pt-md-4 {
    padding-top: 1.5rem !important;
  }

  .p-pt-md-5 {
    padding-top: 2rem !important;
  }

  .p-pt-md-6 {
    padding-top: 3rem !important;
  }

  .p-pr-md-0 {
    padding-right: 0 !important;
  }

  .p-pr-md-1 {
    padding-right: 0.25rem !important;
  }

  .p-pr-md-2 {
    padding-right: 0.5rem !important;
  }

  .p-pr-md-3 {
    padding-right: 1rem !important;
  }

  .p-pr-md-4 {
    padding-right: 1.5rem !important;
  }

  .p-pr-md-5 {
    padding-right: 2rem !important;
  }

  .p-pr-md-6 {
    padding-right: 3rem !important;
  }

  .p-pl-md-0 {
    padding-left: 0 !important;
  }

  .p-pl-md-1 {
    padding-left: 0.25rem !important;
  }

  .p-pl-md-2 {
    padding-left: 0.5rem !important;
  }

  .p-pl-md-3 {
    padding-left: 1rem !important;
  }

  .p-pl-md-4 {
    padding-left: 1.5rem !important;
  }

  .p-pl-md-5 {
    padding-left: 2rem !important;
  }

  .p-pl-md-6 {
    padding-left: 3rem !important;
  }

  .p-pb-md-0 {
    padding-bottom: 0 !important;
  }

  .p-pb-md-1 {
    padding-bottom: 0.25rem !important;
  }

  .p-pb-md-2 {
    padding-bottom: 0.5rem !important;
  }

  .p-pb-md-3 {
    padding-bottom: 1rem !important;
  }

  .p-pb-md-4 {
    padding-bottom: 1.5rem !important;
  }

  .p-pb-md-5 {
    padding-bottom: 2rem !important;
  }

  .p-pb-md-6 {
    padding-bottom: 3rem !important;
  }

  .p-px-md-0 {
    padding-left: 0 !important;
    padding-right: 0 !important;
  }

  .p-px-md-1 {
    padding-left: 0.25rem !important;
    padding-right: 0.25rem !important;
  }

  .p-px-md-2 {
    padding-left: 0.5rem !important;
    padding-right: 0.5rem !important;
  }

  .p-px-md-3 {
    padding-left: 1rem !important;
    padding-right: 1rem !important;
  }

  .p-px-md-4 {
    padding-left: 1.5rem !important;
    padding-right: 1.5rem !important;
  }

  .p-px-md-5 {
    padding-left: 2rem !important;
    padding-right: 2rem !important;
  }

  .p-px-md-6 {
    padding-left: 3rem !important;
    padding-right: 3rem !important;
  }

  .p-py-md-0 {
    padding-top: 0 !important;
    padding-bottom: 0 !important;
  }

  .p-py-md-1 {
    padding-top: 0.25rem !important;
    padding-bottom: 0.25rem !important;
  }

  .p-py-md-2 {
    padding-top: 0.5rem !important;
    padding-bottom: 0.5rem !important;
  }

  .p-py-md-3 {
    padding-top: 1rem !important;
    padding-bottom: 1rem !important;
  }

  .p-py-md-4 {
    padding-top: 1.5rem !important;
    padding-bottom: 1.5rem !important;
  }

  .p-py-md-5 {
    padding-top: 2rem !important;
    padding-bottom: 2rem !important;
  }

  .p-py-md-6 {
    padding-top: 3rem !important;
    padding-bottom: 3rem !important;
  }

  .p-p-md-0 {
    padding: 0 !important;
  }

  .p-p-md-1 {
    padding: 0.25rem !important;
  }

  .p-p-md-2 {
    padding: 0.5rem !important;
  }

  .p-p-md-3 {
    padding: 1rem !important;
  }

  .p-p-md-4 {
    padding: 1.5rem !important;
  }

  .p-p-md-5 {
    padding: 2rem !important;
  }

  .p-p-md-6 {
    padding: 3rem !important;
  }
}
@media screen and (min-width: 992px) {
  .p-pt-lg-0 {
    padding-top: 0 !important;
  }

  .p-pt-lg-1 {
    padding-top: 0.25rem !important;
  }

  .p-pt-lg-2 {
    padding-top: 0.5rem !important;
  }

  .p-pt-lg-3 {
    padding-top: 1rem !important;
  }

  .p-pt-lg-4 {
    padding-top: 1.5rem !important;
  }

  .p-pt-lg-5 {
    padding-top: 2rem !important;
  }

  .p-pt-lg-6 {
    padding-top: 3rem !important;
  }

  .p-pt-lg-auto {
    padding-top: 3rem !important;
  }

  .p-pr-lg-0 {
    padding-right: 0 !important;
  }

  .p-pr-lg-1 {
    padding-right: 0.25rem !important;
  }

  .p-pr-lg-2 {
    padding-right: 0.5rem !important;
  }

  .p-pr-lg-3 {
    padding-right: 1rem !important;
  }

  .p-pr-lg-4 {
    padding-right: 1.5rem !important;
  }

  .p-pr-lg-5 {
    padding-right: 2rem !important;
  }

  .p-pr-lg-6 {
    padding-right: 3rem !important;
  }

  .p-pl-lg-0 {
    padding-left: 0 !important;
  }

  .p-pl-lg-1 {
    padding-left: 0.25rem !important;
  }

  .p-pl-lg-2 {
    padding-left: 0.5rem !important;
  }

  .p-pl-lg-3 {
    padding-left: 1rem !important;
  }

  .p-pl-lg-4 {
    padding-left: 1.5rem !important;
  }

  .p-pl-lg-5 {
    padding-left: 2rem !important;
  }

  .p-pl-lg-6 {
    padding-left: 3rem !important;
  }

  .p-pb-lg-0 {
    padding-bottom: 0 !important;
  }

  .p-pb-lg-1 {
    padding-bottom: 0.25rem !important;
  }

  .p-pb-lg-2 {
    padding-bottom: 0.5rem !important;
  }

  .p-pb-lg-3 {
    padding-bottom: 1rem !important;
  }

  .p-pb-lg-4 {
    padding-bottom: 1.5rem !important;
  }

  .p-pb-lg-5 {
    padding-bottom: 2rem !important;
  }

  .p-pb-lg-6 {
    padding-bottom: 3rem !important;
  }

  .p-px-lg-0 {
    padding-left: 0 !important;
    padding-right: 0 !important;
  }

  .p-px-lg-1 {
    padding-left: 0.25rem !important;
    padding-right: 0.25rem !important;
  }

  .p-px-lg-2 {
    padding-left: 0.5rem !important;
    padding-right: 0.5rem !important;
  }

  .p-px-lg-3 {
    padding-left: 1rem !important;
    padding-right: 1rem !important;
  }

  .p-px-lg-4 {
    padding-left: 1.5rem !important;
    padding-right: 1.5rem !important;
  }

  .p-px-lg-5 {
    padding-left: 2rem !important;
    padding-right: 2rem !important;
  }

  .p-px-lg-6 {
    padding-left: 3rem !important;
    padding-right: 3rem !important;
  }

  .p-py-lg-0 {
    padding-top: 0 !important;
    padding-bottom: 0 !important;
  }

  .p-py-lg-1 {
    padding-top: 0.25rem !important;
    padding-bottom: 0.25rem !important;
  }

  .p-py-lg-2 {
    padding-top: 0.5rem !important;
    padding-bottom: 0.5rem !important;
  }

  .p-py-lg-3 {
    padding-top: 1rem !important;
    padding-bottom: 1rem !important;
  }

  .p-py-lg-4 {
    padding-top: 1.5rem !important;
    padding-bottom: 1.5rem !important;
  }

  .p-py-lg-5 {
    padding-top: 2rem !important;
    padding-bottom: 2rem !important;
  }

  .p-py-lg-6 {
    padding-top: 3rem !important;
    padding-bottom: 3rem !important;
  }

  .p-p-lg-0 {
    padding: 0 !important;
  }

  .p-p-lg-1 {
    padding: 0.25rem !important;
  }

  .p-p-lg-2 {
    padding: 0.5rem !important;
  }

  .p-p-lg-3 {
    padding: 1rem !important;
  }

  .p-p-lg-4 {
    padding: 1.5rem !important;
  }

  .p-p-lg-5 {
    padding: 2rem !important;
  }

  .p-p-lg-6 {
    padding: 3rem !important;
  }
}
@media screen and (min-width: 1200px) {
  .p-pt-xl-0 {
    padding-top: 0 !important;
  }

  .p-pt-xl-1 {
    padding-top: 0.25rem !important;
  }

  .p-pt-xl-2 {
    padding-top: 0.5rem !important;
  }

  .p-pt-xl-3 {
    padding-top: 1rem !important;
  }

  .p-pt-xl-4 {
    padding-top: 1.5rem !important;
  }

  .p-pt-xl-5 {
    padding-top: 2rem !important;
  }

  .p-pt-xl-6 {
    padding-top: 3rem !important;
  }

  .p-pr-xl-0 {
    padding-right: 0 !important;
  }

  .p-pr-xl-1 {
    padding-right: 0.25rem !important;
  }

  .p-pr-xl-2 {
    padding-right: 0.5rem !important;
  }

  .p-pr-xl-3 {
    padding-right: 1rem !important;
  }

  .p-pr-xl-4 {
    padding-right: 1.5rem !important;
  }

  .p-pr-xl-5 {
    padding-right: 2rem !important;
  }

  .p-pr-xl-6 {
    padding-right: 3rem !important;
  }

  .p-pl-xl-0 {
    padding-left: 0 !important;
  }

  .p-pl-xl-1 {
    padding-left: 0.25rem !important;
  }

  .p-pl-xl-2 {
    padding-left: 0.5rem !important;
  }

  .p-pl-xl-3 {
    padding-left: 1rem !important;
  }

  .p-pl-xl-4 {
    padding-left: 1.5rem !important;
  }

  .p-pl-xl-5 {
    padding-left: 2rem !important;
  }

  .p-pl-xl-6 {
    padding-left: 3rem !important;
  }

  .p-pb-xl-0 {
    padding-bottom: 0 !important;
  }

  .p-pb-xl-1 {
    padding-bottom: 0.25rem !important;
  }

  .p-pb-xl-2 {
    padding-bottom: 0.5rem !important;
  }

  .p-pb-xl-3 {
    padding-bottom: 1rem !important;
  }

  .p-pb-xl-4 {
    padding-bottom: 1.5rem !important;
  }

  .p-pb-xl-5 {
    padding-bottom: 2rem !important;
  }

  .p-pb-xl-6 {
    padding-bottom: 3rem !important;
  }

  .p-px-xl-0 {
    padding-left: 0 !important;
    padding-right: 0 !important;
  }

  .p-px-xl-1 {
    padding-left: 0.25rem !important;
    padding-right: 0.25rem !important;
  }

  .p-px-xl-2 {
    padding-left: 0.5rem !important;
    padding-right: 0.5rem !important;
  }

  .p-px-xl-3 {
    padding-left: 1rem !important;
    padding-right: 1rem !important;
  }

  .p-px-xl-4 {
    padding-left: 1.5rem !important;
    padding-right: 1.5rem !important;
  }

  .p-px-xl-5 {
    padding-left: 2rem !important;
    padding-right: 2rem !important;
  }

  .p-px-xl-6 {
    padding-left: 3rem !important;
    padding-right: 3rem !important;
  }

  .p-py-xl-0 {
    padding-top: 0 !important;
    padding-bottom: 0 !important;
  }

  .p-py-xl-1 {
    padding-top: 0.25rem !important;
    padding-bottom: 0.25rem !important;
  }

  .p-py-xl-2 {
    padding-top: 0.5rem !important;
    padding-bottom: 0.5rem !important;
  }

  .p-py-xl-3 {
    padding-top: 1rem !important;
    padding-bottom: 1rem !important;
  }

  .p-py-xl-4 {
    padding-top: 1.5rem !important;
    padding-bottom: 1.5rem !important;
  }

  .p-py-xl-5 {
    padding-top: 2rem !important;
    padding-bottom: 2rem !important;
  }

  .p-py-xl-6 {
    padding-top: 3rem !important;
    padding-bottom: 3rem !important;
  }

  .p-p-xl-0 {
    padding: 0 !important;
  }

  .p-p-xl-1 {
    padding: 0.25rem !important;
  }

  .p-p-xl-2 {
    padding: 0.5rem !important;
  }

  .p-p-xl-3 {
    padding: 1rem !important;
  }

  .p-p-xl-4 {
    padding: 1.5rem !important;
  }

  .p-p-xl-5 {
    padding: 2rem !important;
  }

  .p-p-xl-6 {
    padding: 3rem !important;
  }
}
.p-mt-0 {
  margin-top: 0 !important;
}

.p-mt-1 {
  margin-top: 0.25rem !important;
}

.p-mt-2 {
  margin-top: 0.5rem !important;
}

.p-mt-3 {
  margin-top: 1rem !important;
}

.p-mt-4 {
  margin-top: 1.5rem !important;
}

.p-mt-5 {
  margin-top: 2rem !important;
}

.p-mt-6 {
  margin-top: 3rem !important;
}

.p-mt-auto {
  margin-top: auto !important;
}

.p-mr-0 {
  margin-right: 0 !important;
}

.p-mr-1 {
  margin-right: 0.25rem !important;
}

.p-mr-2 {
  margin-right: 0.5rem !important;
}

.p-mr-3 {
  margin-right: 1rem !important;
}

.p-mr-4 {
  margin-right: 1.5rem !important;
}

.p-mr-5 {
  margin-right: 2rem !important;
}

.p-mr-6 {
  margin-right: 3rem !important;
}

.p-mr-auto {
  margin-right: auto !important;
}

.p-ml-0 {
  margin-left: 0 !important;
}

.p-ml-1 {
  margin-left: 0.25rem !important;
}

.p-ml-2 {
  margin-left: 0.5rem !important;
}

.p-ml-3 {
  margin-left: 1rem !important;
}

.p-ml-4 {
  margin-left: 1.5rem !important;
}

.p-ml-5 {
  margin-left: 2rem !important;
}

.p-ml-6 {
  margin-left: 3rem !important;
}

.p-ml-auto {
  margin-left: auto !important;
}

.p-mb-0 {
  margin-bottom: 0 !important;
}

.p-mb-1 {
  margin-bottom: 0.25rem !important;
}

.p-mb-2 {
  margin-bottom: 0.5rem !important;
}

.p-mb-3 {
  margin-bottom: 1rem !important;
}

.p-mb-4 {
  margin-bottom: 1.5rem !important;
}

.p-mb-5 {
  margin-bottom: 2rem !important;
}

.p-mb-6 {
  margin-bottom: 3rem !important;
}

.p-mb-auto {
  margin-bottom: auto !important;
}

.p-mx-0 {
  margin-left: 0 !important;
  margin-right: 0 !important;
}

.p-mx-1 {
  margin-left: 0.25rem !important;
  margin-right: 0.25rem !important;
}

.p-mx-2 {
  margin-left: 0.5rem !important;
  margin-right: 0.5rem !important;
}

.p-mx-3 {
  margin-left: 1rem !important;
  margin-right: 1rem !important;
}

.p-mx-4 {
  margin-left: 1.5rem !important;
  margin-right: 1.5rem !important;
}

.p-mx-5 {
  margin-left: 2rem !important;
  margin-right: 2rem !important;
}

.p-mx-6 {
  margin-left: 3rem !important;
  margin-right: 3rem !important;
}

.p-mx-auto {
  margin-left: auto !important;
  margin-right: auto !important;
}

.p-my-0 {
  margin-top: 0 !important;
  margin-bottom: 0 !important;
}

.p-my-1 {
  margin-top: 0.25rem !important;
  margin-bottom: 0.25rem !important;
}

.p-my-2 {
  margin-top: 0.5rem !important;
  margin-bottom: 0.5rem !important;
}

.p-my-3 {
  margin-top: 1rem !important;
  margin-bottom: 1rem !important;
}

.p-my-4 {
  margin-top: 1.5rem !important;
  margin-bottom: 1.5rem !important;
}

.p-my-5 {
  margin-top: 2rem !important;
  margin-bottom: 2rem !important;
}

.p-my-6 {
  margin-top: 3rem !important;
  margin-bottom: 3rem !important;
}

.p-my-auto {
  margin-top: auto !important;
  margin-bottom: auto !important;
}

.p-m-0 {
  margin: 0 !important;
}

.p-m-1 {
  margin: 0.25rem !important;
}

.p-m-2 {
  margin: 0.5rem !important;
}

.p-m-3 {
  margin: 1rem !important;
}

.p-m-4 {
  margin: 1.5rem !important;
}

.p-m-5 {
  margin: 2rem !important;
}

.p-m-6 {
  margin: 3rem !important;
}

.p-m-auto {
  margin: auto !important;
}

@media screen and (min-width: 576px) {
  .p-mt-sm-0 {
    margin-top: 0 !important;
  }

  .p-mt-sm-1 {
    margin-top: 0.25rem !important;
  }

  .p-mt-sm-2 {
    margin-top: 0.5rem !important;
  }

  .p-mt-sm-3 {
    margin-top: 1rem !important;
  }

  .p-mt-sm-4 {
    margin-top: 1.5rem !important;
  }

  .p-mt-sm-5 {
    margin-top: 2rem !important;
  }

  .p-mt-sm-6 {
    margin-top: 3rem !important;
  }

  .p-mt-sm-auto {
    margin-top: 3rem !important;
  }

  .p-mr-sm-0 {
    margin-right: 0 !important;
  }

  .p-mr-sm-1 {
    margin-right: 0.25rem !important;
  }

  .p-mr-sm-2 {
    margin-right: 0.5rem !important;
  }

  .p-mr-sm-3 {
    margin-right: 1rem !important;
  }

  .p-mr-sm-4 {
    margin-right: 1.5rem !important;
  }

  .p-mr-sm-5 {
    margin-right: 2rem !important;
  }

  .p-mr-sm-6 {
    margin-right: 3rem !important;
  }

  .p-mr-sm-auto {
    margin-right: auto !important;
  }

  .p-ml-sm-0 {
    margin-left: 0 !important;
  }

  .p-ml-sm-1 {
    margin-left: 0.25rem !important;
  }

  .p-ml-sm-2 {
    margin-left: 0.5rem !important;
  }

  .p-ml-sm-3 {
    margin-left: 1rem !important;
  }

  .p-ml-sm-4 {
    margin-left: 1.5rem !important;
  }

  .p-ml-sm-5 {
    margin-left: 2rem !important;
  }

  .p-ml-sm-6 {
    margin-left: 3rem !important;
  }

  .p-ml-sm-auto {
    margin-left: auto !important;
  }

  .p-mb-sm-0 {
    margin-bottom: 0 !important;
  }

  .p-mb-sm-1 {
    margin-bottom: 0.25rem !important;
  }

  .p-mb-sm-2 {
    margin-bottom: 0.5rem !important;
  }

  .p-mb-sm-3 {
    margin-bottom: 1rem !important;
  }

  .p-mb-sm-4 {
    margin-bottom: 1.5rem !important;
  }

  .p-mb-sm-5 {
    margin-bottom: 2rem !important;
  }

  .p-mb-sm-6 {
    margin-bottom: 3rem !important;
  }

  .p-mb-sm-auto {
    margin-bottom: auto !important;
  }

  .p-mx-sm-0 {
    margin-left: 0 !important;
    margin-right: 0 !important;
  }

  .p-mx-sm-1 {
    margin-left: 0.25rem !important;
    margin-right: 0.25rem !important;
  }

  .p-mx-sm-2 {
    margin-left: 0.5rem !important;
    margin-right: 0.5rem !important;
  }

  .p-mx-sm-3 {
    margin-left: 1rem !important;
    margin-right: 1rem !important;
  }

  .p-mx-sm-4 {
    margin-left: 1.5rem !important;
    margin-right: 1.5rem !important;
  }

  .p-mx-sm-5 {
    margin-left: 2rem !important;
    margin-right: 2rem !important;
  }

  .p-mx-sm-6 {
    margin-left: 3rem !important;
    margin-right: 3rem !important;
  }

  .p-mx-sm-auto {
    margin-left: auto !important;
    margin-right: auto !important;
  }

  .p-my-sm-0 {
    margin-top: 0 !important;
    margin-bottom: 0 !important;
  }

  .p-my-sm-1 {
    margin-top: 0.25rem !important;
    margin-bottom: 0.25rem !important;
  }

  .p-my-sm-2 {
    margin-top: 0.5rem !important;
    margin-bottom: 0.5rem !important;
  }

  .p-my-sm-3 {
    margin-top: 1rem !important;
    margin-bottom: 1rem !important;
  }

  .p-my-sm-4 {
    margin-top: 1.5rem !important;
    margin-bottom: 1.5rem !important;
  }

  .p-my-sm-5 {
    margin-top: 2rem !important;
    margin-bottom: 2rem !important;
  }

  .p-my-sm-6 {
    margin-top: 3rem !important;
    margin-bottom: 3rem !important;
  }

  .p-my-sm-auto {
    margin-top: auto !important;
    margin-bottom: auto !important;
  }

  .p-m-sm-0 {
    margin: 0 !important;
  }

  .p-m-sm-1 {
    margin: 0.25rem !important;
  }

  .p-m-sm-2 {
    margin: 0.5rem !important;
  }

  .p-m-sm-3 {
    margin: 1rem !important;
  }

  .p-m-sm-4 {
    margin: 1.5rem !important;
  }

  .p-m-sm-5 {
    margin: 2rem !important;
  }

  .p-m-sm-6 {
    margin: 3rem !important;
  }

  .p-m-sm-auto {
    margin: auto !important;
  }
}
@media screen and (min-width: 768px) {
  .p-mt-md-0 {
    margin-top: 0 !important;
  }

  .p-mt-md-1 {
    margin-top: 0.25rem !important;
  }

  .p-mt-md-2 {
    margin-top: 0.5rem !important;
  }

  .p-mt-md-3 {
    margin-top: 1rem !important;
  }

  .p-mt-md-4 {
    margin-top: 1.5rem !important;
  }

  .p-mt-md-5 {
    margin-top: 2rem !important;
  }

  .p-mt-md-6 {
    margin-top: 3rem !important;
  }

  .p-mt-md-auto {
    margin-top: 3rem !important;
  }

  .p-mr-md-0 {
    margin-right: 0 !important;
  }

  .p-mr-md-1 {
    margin-right: 0.25rem !important;
  }

  .p-mr-md-2 {
    margin-right: 0.5rem !important;
  }

  .p-mr-md-3 {
    margin-right: 1rem !important;
  }

  .p-mr-md-4 {
    margin-right: 1.5rem !important;
  }

  .p-mr-md-5 {
    margin-right: 2rem !important;
  }

  .p-mr-md-6 {
    margin-right: 3rem !important;
  }

  .p-mr-md-auto {
    margin-right: auto !important;
  }

  .p-ml-md-0 {
    margin-left: 0 !important;
  }

  .p-ml-md-1 {
    margin-left: 0.25rem !important;
  }

  .p-ml-md-2 {
    margin-left: 0.5rem !important;
  }

  .p-ml-md-3 {
    margin-left: 1rem !important;
  }

  .p-ml-md-4 {
    margin-left: 1.5rem !important;
  }

  .p-ml-md-5 {
    margin-left: 2rem !important;
  }

  .p-ml-md-6 {
    margin-left: 3rem !important;
  }

  .p-ml-md-auto {
    margin-left: auto !important;
  }

  .p-mb-md-0 {
    margin-bottom: 0 !important;
  }

  .p-mb-md-1 {
    margin-bottom: 0.25rem !important;
  }

  .p-mb-md-2 {
    margin-bottom: 0.5rem !important;
  }

  .p-mb-md-3 {
    margin-bottom: 1rem !important;
  }

  .p-mb-md-4 {
    margin-bottom: 1.5rem !important;
  }

  .p-mb-md-5 {
    margin-bottom: 2rem !important;
  }

  .p-mb-md-6 {
    margin-bottom: 3rem !important;
  }

  .p-mb-md-auto {
    margin-bottom: auto !important;
  }

  .p-mx-md-0 {
    margin-left: 0 !important;
    margin-right: 0 !important;
  }

  .p-mx-md-1 {
    margin-left: 0.25rem !important;
    margin-right: 0.25rem !important;
  }

  .p-mx-md-2 {
    margin-left: 0.5rem !important;
    margin-right: 0.5rem !important;
  }

  .p-mx-md-3 {
    margin-left: 1rem !important;
    margin-right: 1rem !important;
  }

  .p-mx-md-4 {
    margin-left: 1.5rem !important;
    margin-right: 1.5rem !important;
  }

  .p-mx-md-5 {
    margin-left: 2rem !important;
    margin-right: 2rem !important;
  }

  .p-mx-md-6 {
    margin-left: 3rem !important;
    margin-right: 3rem !important;
  }

  .p-mx-md-auto {
    margin-left: auto !important;
    margin-right: auto !important;
  }

  .p-my-md-0 {
    margin-top: 0 !important;
    margin-bottom: 0 !important;
  }

  .p-my-md-1 {
    margin-top: 0.25rem !important;
    margin-bottom: 0.25rem !important;
  }

  .p-my-md-2 {
    margin-top: 0.5rem !important;
    margin-bottom: 0.5rem !important;
  }

  .p-my-md-3 {
    margin-top: 1rem !important;
    margin-bottom: 1rem !important;
  }

  .p-my-md-4 {
    margin-top: 1.5rem !important;
    margin-bottom: 1.5rem !important;
  }

  .p-my-md-5 {
    margin-top: 2rem !important;
    margin-bottom: 2rem !important;
  }

  .p-my-md-6 {
    margin-top: 3rem !important;
    margin-bottom: 3rem !important;
  }

  .p-my-md-auto {
    margin-top: auto !important;
    margin-bottom: auto !important;
  }

  .p-m-md-0 {
    margin: 0 !important;
  }

  .p-m-md-1 {
    margin: 0.25rem !important;
  }

  .p-m-md-2 {
    margin: 0.5rem !important;
  }

  .p-m-md-3 {
    margin: 1rem !important;
  }

  .p-m-md-4 {
    margin: 1.5rem !important;
  }

  .p-m-md-5 {
    margin: 2rem !important;
  }

  .p-m-md-6 {
    margin: 3rem !important;
  }

  .p-m-md-auto {
    margin: auto !important;
  }
}
@media screen and (min-width: 992px) {
  .p-mt-lg-0 {
    margin-top: 0 !important;
  }

  .p-mt-lg-1 {
    margin-top: 0.25rem !important;
  }

  .p-mt-lg-2 {
    margin-top: 0.5rem !important;
  }

  .p-mt-lg-3 {
    margin-top: 1rem !important;
  }

  .p-mt-lg-4 {
    margin-top: 1.5rem !important;
  }

  .p-mt-lg-5 {
    margin-top: 2rem !important;
  }

  .p-mt-lg-6 {
    margin-top: 3rem !important;
  }

  .p-mt-lg-auto {
    margin-top: 3rem !important;
  }

  .p-mr-lg-0 {
    margin-right: 0 !important;
  }

  .p-mr-lg-1 {
    margin-right: 0.25rem !important;
  }

  .p-mr-lg-2 {
    margin-right: 0.5rem !important;
  }

  .p-mr-lg-3 {
    margin-right: 1rem !important;
  }

  .p-mr-lg-4 {
    margin-right: 1.5rem !important;
  }

  .p-mr-lg-5 {
    margin-right: 2rem !important;
  }

  .p-mr-lg-6 {
    margin-right: 3rem !important;
  }

  .p-mr-lg-auto {
    margin-right: auto !important;
  }

  .p-ml-lg-0 {
    margin-left: 0 !important;
  }

  .p-ml-lg-1 {
    margin-left: 0.25rem !important;
  }

  .p-ml-lg-2 {
    margin-left: 0.5rem !important;
  }

  .p-ml-lg-3 {
    margin-left: 1rem !important;
  }

  .p-ml-lg-4 {
    margin-left: 1.5rem !important;
  }

  .p-ml-lg-5 {
    margin-left: 2rem !important;
  }

  .p-ml-lg-6 {
    margin-left: 3rem !important;
  }

  .p-ml-lg-auto {
    margin-left: auto !important;
  }

  .p-mb-lg-0 {
    margin-bottom: 0 !important;
  }

  .p-mb-lg-1 {
    margin-bottom: 0.25rem !important;
  }

  .p-mb-lg-2 {
    margin-bottom: 0.5rem !important;
  }

  .p-mb-lg-3 {
    margin-bottom: 1rem !important;
  }

  .p-mb-lg-4 {
    margin-bottom: 1.5rem !important;
  }

  .p-mb-lg-5 {
    margin-bottom: 2rem !important;
  }

  .p-mb-lg-6 {
    margin-bottom: 3rem !important;
  }

  .p-mb-lg-auto {
    margin-bottom: auto !important;
  }

  .p-mx-lg-0 {
    margin-left: 0 !important;
    margin-right: 0 !important;
  }

  .p-mx-lg-1 {
    margin-left: 0.25rem !important;
    margin-right: 0.25rem !important;
  }

  .p-mx-lg-2 {
    margin-left: 0.5rem !important;
    margin-right: 0.5rem !important;
  }

  .p-mx-lg-3 {
    margin-left: 1rem !important;
    margin-right: 1rem !important;
  }

  .p-mx-lg-4 {
    margin-left: 1.5rem !important;
    margin-right: 1.5rem !important;
  }

  .p-mx-lg-5 {
    margin-left: 2rem !important;
    margin-right: 2rem !important;
  }

  .p-mx-lg-6 {
    margin-left: 3rem !important;
    margin-right: 3rem !important;
  }

  .p-mx-lg-auto {
    margin-left: auto !important;
    margin-right: auto !important;
  }

  .p-my-lg-0 {
    margin-top: 0 !important;
    margin-bottom: 0 !important;
  }

  .p-my-lg-1 {
    margin-top: 0.25rem !important;
    margin-bottom: 0.25rem !important;
  }

  .p-my-lg-2 {
    margin-top: 0.5rem !important;
    margin-bottom: 0.5rem !important;
  }

  .p-my-lg-3 {
    margin-top: 1rem !important;
    margin-bottom: 1rem !important;
  }

  .p-my-lg-4 {
    margin-top: 1.5rem !important;
    margin-bottom: 1.5rem !important;
  }

  .p-my-lg-5 {
    margin-top: 2rem !important;
    margin-bottom: 2rem !important;
  }

  .p-my-lg-6 {
    margin-top: 3rem !important;
    margin-bottom: 3rem !important;
  }

  .p-my-lg-auto {
    margin-top: auto !important;
    margin-bottom: auto !important;
  }

  .p-m-lg-0 {
    margin: 0 !important;
  }

  .p-m-lg-1 {
    margin: 0.25rem !important;
  }

  .p-m-lg-2 {
    margin: 0.5rem !important;
  }

  .p-m-lg-3 {
    margin: 1rem !important;
  }

  .p-m-lg-4 {
    margin: 1.5rem !important;
  }

  .p-m-lg-5 {
    margin: 2rem !important;
  }

  .p-m-lg-6 {
    margin: 3rem !important;
  }

  .p-m-lg-auto {
    margin: auto !important;
  }
}
@media screen and (min-width: 1200px) {
  .p-mt-xl-0 {
    margin-top: 0 !important;
  }

  .p-mt-xl-1 {
    margin-top: 0.25rem !important;
  }

  .p-mt-xl-2 {
    margin-top: 0.5rem !important;
  }

  .p-mt-xl-3 {
    margin-top: 1rem !important;
  }

  .p-mt-xl-4 {
    margin-top: 1.5rem !important;
  }

  .p-mt-xl-5 {
    margin-top: 2rem !important;
  }

  .p-mt-xl-6 {
    margin-top: 3rem !important;
  }

  .p-mt-xl-auto {
    margin-top: 3rem !important;
  }

  .p-mr-xl-0 {
    margin-right: 0 !important;
  }

  .p-mr-xl-1 {
    margin-right: 0.25rem !important;
  }

  .p-mr-xl-2 {
    margin-right: 0.5rem !important;
  }

  .p-mr-xl-3 {
    margin-right: 1rem !important;
  }

  .p-mr-xl-4 {
    margin-right: 1.5rem !important;
  }

  .p-mr-xl-5 {
    margin-right: 2rem !important;
  }

  .p-mr-xl-6 {
    margin-right: 3rem !important;
  }

  .p-mr-xl-auto {
    margin-right: auto !important;
  }

  .p-ml-xl-0 {
    margin-left: 0 !important;
  }

  .p-ml-xl-1 {
    margin-left: 0.25rem !important;
  }

  .p-ml-xl-2 {
    margin-left: 0.5rem !important;
  }

  .p-ml-xl-3 {
    margin-left: 1rem !important;
  }

  .p-ml-xl-4 {
    margin-left: 1.5rem !important;
  }

  .p-ml-xl-5 {
    margin-left: 2rem !important;
  }

  .p-ml-xl-6 {
    margin-left: 3rem !important;
  }

  .p-ml-xl-auto {
    margin-left: auto !important;
  }

  .p-mb-xl-0 {
    margin-bottom: 0 !important;
  }

  .p-mb-xl-1 {
    margin-bottom: 0.25rem !important;
  }

  .p-mb-xl-2 {
    margin-bottom: 0.5rem !important;
  }

  .p-mb-xl-3 {
    margin-bottom: 1rem !important;
  }

  .p-mb-xl-4 {
    margin-bottom: 1.5rem !important;
  }

  .p-mb-xl-5 {
    margin-bottom: 2rem !important;
  }

  .p-mb-xl-6 {
    margin-bottom: 3rem !important;
  }

  .p-mb-xl-auto {
    margin-bottom: auto !important;
  }

  .p-mx-xl-0 {
    margin-left: 0 !important;
    margin-right: 0 !important;
  }

  .p-mx-xl-1 {
    margin-left: 0.25rem !important;
    margin-right: 0.25rem !important;
  }

  .p-mx-xl-2 {
    margin-left: 0.5rem !important;
    margin-right: 0.5rem !important;
  }

  .p-mx-xl-3 {
    margin-left: 1rem !important;
    margin-right: 1rem !important;
  }

  .p-mx-xl-4 {
    margin-left: 1.5rem !important;
    margin-right: 1.5rem !important;
  }

  .p-mx-xl-5 {
    margin-left: 2rem !important;
    margin-right: 2rem !important;
  }

  .p-mx-xl-6 {
    margin-left: 3rem !important;
    margin-right: 3rem !important;
  }

  .p-mx-xl-auto {
    margin-left: auto !important;
    margin-right: auto !important;
  }

  .p-my-xl-0 {
    margin-top: 0 !important;
    margin-bottom: 0 !important;
  }

  .p-my-xl-1 {
    margin-top: 0.25rem !important;
    margin-bottom: 0.25rem !important;
  }

  .p-my-xl-2 {
    margin-top: 0.5rem !important;
    margin-bottom: 0.5rem !important;
  }

  .p-my-xl-3 {
    margin-top: 1rem !important;
    margin-bottom: 1rem !important;
  }

  .p-my-xl-4 {
    margin-top: 1.5rem !important;
    margin-bottom: 1.5rem !important;
  }

  .p-my-xl-5 {
    margin-top: 2rem !important;
    margin-bottom: 2rem !important;
  }

  .p-my-xl-6 {
    margin-top: 3rem !important;
    margin-bottom: 3rem !important;
  }

  .p-my-xl-auto {
    margin-top: auto !important;
    margin-bottom: auto !important;
  }

  .p-m-xl-0 {
    margin: 0 !important;
  }

  .p-m-xl-1 {
    margin: 0.25rem !important;
  }

  .p-m-xl-2 {
    margin: 0.5rem !important;
  }

  .p-m-xl-3 {
    margin: 1rem !important;
  }

  .p-m-xl-4 {
    margin: 1.5rem !important;
  }

  .p-m-xl-5 {
    margin: 2rem !important;
  }

  .p-m-xl-6 {
    margin: 3rem !important;
  }

  .p-m-xl-auto {
    margin: auto !important;
  }
}
.p-shadow-1 {
  box-shadow: 0 2px 1px -1px rgba(0, 0, 0, 0.2), 0 1px 1px 0 rgba(0, 0, 0, 0.14), 0 1px 3px 0 rgba(0, 0, 0, 0.12);
}

.p-shadow-2 {
  box-shadow: 0 3px 1px -2px rgba(0, 0, 0, 0.2), 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 1px 5px 0 rgba(0, 0, 0, 0.12);
}

.p-shadow-3 {
  box-shadow: 0 3px 3px -2px rgba(0, 0, 0, 0.2), 0 3px 4px 0 rgba(0, 0, 0, 0.14), 0 1px 8px 0 rgba(0, 0, 0, 0.12);
}

.p-shadow-4 {
  box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
}

.p-shadow-5 {
  box-shadow: 0 3px 5px -1px rgba(0, 0, 0, 0.2), 0 5px 8px 0 rgba(0, 0, 0, 0.14), 0 1px 14px 0 rgba(0, 0, 0, 0.12);
}

.p-shadow-6 {
  box-shadow: 0 3px 5px -1px rgba(0, 0, 0, 0.2), 0 6px 10px 0 rgba(0, 0, 0, 0.14), 0 1px 18px 0 rgba(0, 0, 0, 0.12);
}

.p-shadow-7 {
  box-shadow: 0 4px 5px -2px rgba(0, 0, 0, 0.2), 0 7px 10px 1px rgba(0, 0, 0, 0.14), 0 2px 16px 1px rgba(0, 0, 0, 0.12);
}

.p-shadow-8 {
  box-shadow: 0 5px 5px -3px rgba(0, 0, 0, 0.2), 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12);
}

.p-shadow-9 {
  box-shadow: 0 5px 6px -3px rgba(0, 0, 0, 0.2), 0 9px 12px 1px rgba(0, 0, 0, 0.14), 0 3px 16px 2px rgba(0, 0, 0, 0.12);
}

.p-shadow-10 {
  box-shadow: 0 6px 6px -3px rgba(0, 0, 0, 0.2), 0 10px 14px 1px rgba(0, 0, 0, 0.14), 0 4px 18px 3px rgba(0, 0, 0, 0.12);
}

.p-shadow-11 {
  box-shadow: 0 6px 7px -4px rgba(0, 0, 0, 0.2), 0 11px 15px 1px rgba(0, 0, 0, 0.14), 0 4px 20px 3px rgba(0, 0, 0, 0.12);
}

.p-shadow-12 {
  box-shadow: 0 7px 8px -4px rgba(0, 0, 0, 0.2), 0 12px 17px 2px rgba(0, 0, 0, 0.14), 0 5px 22px 4px rgba(0, 0, 0, 0.12);
}

.p-shadow-13 {
  box-shadow: 0 7px 8px -4px rgba(0, 0, 0, 0.2), 0 13px 19px 2px rgba(0, 0, 0, 0.14), 0 5px 24px 4px rgba(0, 0, 0, 0.12);
}

.p-shadow-14 {
  box-shadow: 0 7px 9px -4px rgba(0, 0, 0, 0.2), 0 14px 21px 2px rgba(0, 0, 0, 0.14), 0 5px 26px 4px rgba(0, 0, 0, 0.12);
}

.p-shadow-15 {
  box-shadow: 0 8px 9px -5px rgba(0, 0, 0, 0.2), 0 15px 22px 2px rgba(0, 0, 0, 0.14), 0 6px 28px 5px rgba(0, 0, 0, 0.12);
}

.p-shadow-16 {
  box-shadow: 0 8px 10px -5px rgba(0, 0, 0, 0.2), 0 16px 24px 2px rgba(0, 0, 0, 0.14), 0 6px 30px 5px rgba(0, 0, 0, 0.12);
}

.p-shadow-17 {
  box-shadow: 0 8px 11px -5px rgba(0, 0, 0, 0.2), 0 17px 26px 2px rgba(0, 0, 0, 0.14), 0 6px 32px 5px rgba(0, 0, 0, 0.12);
}

.p-shadow-18 {
  box-shadow: 0 9px 11px -5px rgba(0, 0, 0, 0.2), 0 18px 28px 2px rgba(0, 0, 0, 0.14), 0 7px 34px 6px rgba(0, 0, 0, 0.12);
}

.p-shadow-19 {
  box-shadow: 0 9px 12px -6px rgba(0, 0, 0, 0.2), 0 19px 29px 2px rgba(0, 0, 0, 0.14), 0 7px 36px 6px rgba(0, 0, 0, 0.12);
}

.p-shadow-20 {
  box-shadow: 0 10px 13px -6px rgba(0, 0, 0, 0.2), 0 20px 31px 3px rgba(0, 0, 0, 0.14), 0 8px 38px 7px rgba(0, 0, 0, 0.12);
}

.p-shadow-21 {
  box-shadow: 0 10px 13px -6px rgba(0, 0, 0, 0.2), 0 21px 33px 3px rgba(0, 0, 0, 0.14), 0 8px 40px 7px rgba(0, 0, 0, 0.12);
}

.p-shadow-22 {
  box-shadow: 0 10px 14px -6px rgba(0, 0, 0, 0.2), 0 22px 35px 3px rgba(0, 0, 0, 0.14), 0 8px 42px 7px rgba(0, 0, 0, 0.12);
}

.p-shadow-23 {
  box-shadow: 0 11px 14px -7px rgba(0, 0, 0, 0.2), 0 23px 36px 3px rgba(0, 0, 0, 0.14), 0 9px 44px 8px rgba(0, 0, 0, 0.12);
}

.p-shadow-24 {
  box-shadow: 0 11px 15px -7px rgba(0, 0, 0, 0.2), 0 24px 38px 3px rgba(0, 0, 0, 0.14), 0 9px 46px 8px rgba(0, 0, 0, 0.12);
}
</style>`;

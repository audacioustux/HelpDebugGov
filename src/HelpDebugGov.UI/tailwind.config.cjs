/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{html,js,svelte,ts}'],
  theme: {
    extend: {
      fontFamily: {
        sans: ['"Work SansVariable"', ...defaultTheme.fontFamily.sans],
        serif: ['"Playfair DisplayVariable"', ...defaultTheme.fontFamily.serif],

      },
    }
  },
  plugins: []
};
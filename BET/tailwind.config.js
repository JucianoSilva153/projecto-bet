// tailwind.config.js

/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './*.html', // Ajuste este caminho para onde estão seus arquivos HTML
    ],
    theme: {
        extend: {
            colors: {
                'primary': '#38bdf8',
                'secondary': '#a1dfff',
            },
        },
    },
    plugins: [],
};
import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  build: {
    outDir: '../api/EFM.Api/wwwroot',
    chunkSizeWarningLimit: 1024,
    emptyOutDir: true
  }
});

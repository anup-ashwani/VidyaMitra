FROM node:18-alpine AS build
WORKDIR /

# install deps
COPY package.json /app/package-lock.json* ./
RUN npm ci --silent || npm install --silent

WORKDIR /app
# copy sources and build
COPY . .
RUN npm run build

FROM nginx:stable-alpine AS production
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

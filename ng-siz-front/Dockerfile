FROM nginx:1.15.4-alpine

COPY dist/ng-siz-front /usr/share/nginx/html
# Create your own nginx configuration and copy it here
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

CMD ["/bin/sh",  "-c",  "envsubst < /usr/share/nginx/html/assets/env.template.js > /usr/share/nginx/html/assets/env.js && exec nginx -g 'daemon off;'"]
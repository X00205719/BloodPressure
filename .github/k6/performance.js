import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    duration: '1m',
    vus: 50,
    thresholds: {
        http_req_failed: ['rate<0.01'], // http errors should be less than 1%
    },
};

export default function () {
    const res = http.get('https://inte-bloodpressurecalculator-staging.azurewebsites.net');
    sleep(1);
}
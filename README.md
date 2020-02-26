# AppMetrics

In order to collect metrics follow these steps:
1. download prometheus https://prometheus.io/download/
2. download grafana https://grafana.com/grafana/download
3. configure prometheus to your api with something like this:
   * in prometheus.yml file in scrape_configs section at very bottom
     add:
     - job_name: 'customersapi'
        static_configs:
        - targets: ['localhost:5000'] // this is your appllication uri
        metrics_path: /metrics-text
   * run prometheus.exe // default prometheus url is localhost:9090
4. run grafana-server.exe // default grafana url is localhost:3000. default login: admin, default pass: admin
5. go to localhost:3000 and choose data source as prometheus
6. This is pretty much everything you need. Once your application start reciving request prometheus will 
   scrape it every 15s (configures in prometheus.yml file) and grafana will read that data.
